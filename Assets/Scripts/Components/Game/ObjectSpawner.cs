﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //For Context:
    //Safe area - area inside innerCollider. Must be safe zone without spawns inside of it
    //Outside safe area - area between innerCollider and outerCollider. Zone for spawn stuff
    [SerializeField]
    private BoxCollider2D innerCollider;
    [SerializeField]
    private BoxCollider2D outerCollider;

    private LevelSettings levelSettings;
    private int SaucersThisLevelCounter { get; set; }
    private List<GameObject> currentSaucers = new List<GameObject>();

    private int MaxSaucerAmountForCurrentStage
    {
        get => levelSettings.MaxSaucersForLevel + GameCore.Instance.CurrentStage / levelSettings.IncreaseMaxSaucerOnScreenEachLevels;
    }

    private void Start()
    {
        levelSettings = GameCore.Instance.References.LevelSettings;

        GameCore.Instance.NewLevelInit += SpawnLevelObjects;
        GameCore.Instance.StageCleared += StopSpawning;
        GameCore.Instance.GameIsOver += StopSpawning;
    }

    private void SpawnLevelObjects()
    {
        ResetComponent();
        //asteroids
        var asteroidsAmount = levelSettings.BaseAsteroidAmount + levelSettings.AdditionalAsteroidsEachStage * (GameCore.Instance.CurrentStage - 1);
        if (asteroidsAmount > levelSettings.AsteroidsMaxAmount)
            asteroidsAmount = levelSettings.AsteroidsMaxAmount;
        for (var i = 0; i < asteroidsAmount; i++)
            SpawnAsteroid();

        //start saucer spawn timer
        StartCoroutine(PeriodicSaucerSpawn());
    }

    private void ResetComponent()
    {
        StopAllCoroutines();
        SaucersThisLevelCounter = 0;
        currentSaucers.Clear();
    }
         
    private IEnumerator PeriodicSaucerSpawn()
    {
        while (SaucersThisLevelCounter <= MaxSaucerAmountForCurrentStage)
        {
            //Dont spawn new saucer if player isn't alive
            if (!GameCore.Instance.PlayerShip.activeSelf)
                yield return new WaitForSeconds(levelSettings.DelayUntilSpawnNewSaucer);

            for (var i=0; i<currentSaucers.Count; i++)
            {
                if (!currentSaucers[i]) currentSaucers.RemoveAt(i);
            }
            //Delay new saucer spawn if there current saucers amount on screen is max
            if (currentSaucers.Count >= levelSettings.MaxSaucersOnScreen)
            {
                //print($"Many S on screen - on screen:{currentSaucers.Count} onThisLevelBefore:{SaucersThisLevelCounter} maxOnScreen:{levelSettings.MaxSaucersOnScreen}");
                yield return new WaitForSeconds(levelSettings.DelayUntilSpawnNewSaucer);
                continue;
            }
            //print($"Can spawn more - on screen:{currentSaucers.Count} onThisLevelBefore:{SaucersThisLevelCounter} maxOnScreen:{levelSettings.MaxSaucersOnScreen}");
            yield return new WaitForSeconds(levelSettings.SaucerSpawnTimer);

            //Decide saucer type to spawn. If all of them can spawn on current level - picks random
            bool canSpawnBigSaucer = GameCore.Instance.CurrentStage <= levelSettings.LastBigSaucerLevelApperance;
            bool canSpawnSmallSaucer = GameCore.Instance.CurrentStage >= levelSettings.LittleSaucerFirstLevelAppearance;
            if (canSpawnBigSaucer && canSpawnSmallSaucer)
            {
                //If there only 1 saucer left to spawn this stage - chooses to spawn small saucer
                if (MaxSaucerAmountForCurrentStage - SaucersThisLevelCounter == 1)
                {
                    currentSaucers.Add(SpawnSmallSaucer());
                }  
                //Otherwise just pick random
                else if (Random.Range(0, 2) == 0) currentSaucers.Add(SpawnBigSaucer());
                else currentSaucers.Add(SpawnSmallSaucer());
            }
            else if (canSpawnBigSaucer)
            {
                currentSaucers.Add(SpawnBigSaucer());
            }
            else if (canSpawnSmallSaucer)
            {
                currentSaucers.Add(SpawnSmallSaucer());
            }
            SaucersThisLevelCounter++;
        }
    }

    private GameObject SpawnSmallSaucer()
    {
        return Instantiate(GameCore.Instance.References.SaucersSettings.SmallSaucer.SaucerObjPrefab, GetRandomPointNearTheBorder(), Quaternion.identity);
    }

    private GameObject SpawnBigSaucer()
    {
        return Instantiate(GameCore.Instance.References.SaucersSettings.BigSaucer.SaucerObjPrefab, GetRandomPointNearTheBorder(), Quaternion.identity);
    }

    private void SpawnAsteroid()
    {
        Instantiate(GameCore.Instance.References.AsteroidsSettings.AsteroidBaseObject, GetRandomPointBetweenColliders(), Quaternion.identity);
    }

    private void StopSpawning()
    {
        StopAllCoroutines();
    }

    private Vector2 GetRandomPointNearTheBorder()
    {
        var somePoint = GetRandomPointBetweenColliders();
        var sidePicker = Random.Range(0, 2);
        if (sidePicker == 0)
            somePoint.x = outerCollider.bounds.min.x;
        else somePoint.x = outerCollider.bounds.max.x;

        return somePoint;
    }

    private Vector2 GetRandomPointBetweenColliders()
    {
        return GetRandomPointBetweenColliders(innerCollider, outerCollider);
    }

    public static Vector2 GetRandomPointBetweenColliders(BoxCollider2D innerCollider, BoxCollider2D outerCollider)
    {
        Vector2 newPoint;

        var outerX = new { Min = outerCollider.bounds.min.x, Max = outerCollider.bounds.max.x };
        var outerY = new { Min = outerCollider.bounds.min.y, Max = outerCollider.bounds.max.y };
        var innerX = new { Min = innerCollider.bounds.min.x, Max = innerCollider.bounds.max.x };
        var innerY = new { Min = innerCollider.bounds.min.y, Max = innerCollider.bounds.max.y };

        //Robust approach
        //pick random point and check if it fitting in outside of safe area
        int testCounter = 0;
        while (true)
        {
            newPoint.x = Random.Range(outerX.Min, outerX.Max);
            newPoint.y = Random.Range(outerY.Min, outerY.Max);

            if (newPoint.x < innerX.Max && newPoint.x > innerX.Min && newPoint.y < innerY.Max && newPoint.y > innerY.Min)
            {
                if (testCounter++ > 100) throw new System.Exception($"Object spawner: failed to pick random point ({testCounter} attempts)");
            }
            else break;
        }
        return newPoint;
    }
}
