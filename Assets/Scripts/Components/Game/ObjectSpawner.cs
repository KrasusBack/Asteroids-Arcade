using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    //For Context:
    //Safe area - area inside innerCollider
    //Outside safe area - area between innerCollider and outerCollider
    [SerializeField]
    private BoxCollider2D innerCollider;
    [SerializeField]
    private BoxCollider2D outerCollider;

    private LevelSettings levelSettings;
    private int SaucersThisLevelCounter { get; set; }

    private void Start()
    {
        levelSettings = GameCore.Instance.LevelSettings;

        GameCore.Instance.NewLevelStarted += SpawnLevelObjects;
        GameCore.Instance.StageCleared += StopSpawning;
    }

    private void SpawnLevelObjects()
    {
        StopAllCoroutines();
        SaucersThisLevelCounter = 0;
        //asteroids
        var asteroidsAmount = levelSettings.BaseAsteroidAmount + levelSettings.AdditionalAsteroidsEachStage * (GameCore.Instance.CurrentStage - 1);
        if (asteroidsAmount > levelSettings.AsteroidsMaxAmount)
            asteroidsAmount = levelSettings.AsteroidsMaxAmount;
        for (var i = 0; i < asteroidsAmount; i++)
            SpawnAsteroid();

        //start saucer spawn timer
        StartCoroutine(PeriodicSaucerSpawn());
    }

    private IEnumerator PeriodicSaucerSpawn()
    {
        while (SaucersThisLevelCounter<=GameCore.Instance.LevelSettings.MaxSaucersForLevel)
        {
            print("ObjectSpawner:" + levelSettings.SaucerSpawnTimer + " before saucer spawn");
            yield return new WaitForSeconds(levelSettings.SaucerSpawnTimer);

            //decide saucer type to spawn
            if (GameCore.Instance.CurrentStage <= levelSettings.LastBigSaucerLevelApperance)
            {
                SpawnBigSaucer();
            }
            else if (GameCore.Instance.CurrentStage >= levelSettings.LittleSaucerFirstLevelAppearance)
            {
                SpawnSmallSaucer();
            }
            SaucersThisLevelCounter++;
        }
    }

    private void SpawnSmallSaucer()
    {
        Instantiate(GameCore.Instance.SaucersSettings.SmallSaucer.SaucerObjPrefab, GetRandomPointNearTheBorder(), Quaternion.identity);
    }

    private void SpawnBigSaucer()
    {
        Instantiate(GameCore.Instance.SaucersSettings.BigSaucer.SaucerObjPrefab, GetRandomPointNearTheBorder(), Quaternion.identity);
    }

    private void SpawnAsteroid()
    {
        Instantiate(GameCore.Instance.AsteroidsSettings.AsteroidBaseObject, GetRandomPointOutsideSafeArea(), Quaternion.identity);
    }

    private void StopSpawning()
    {
        StopAllCoroutines();
    }

    private Vector2 GetRandomPointNearTheBorder()
    {
        var somePoint = GetRandomPointOutsideSafeArea();
        var sidePicker = Random.Range(0, 2);
        if (sidePicker==0)
            somePoint.x = outerCollider.bounds.min.x;
        else somePoint.x = outerCollider.bounds.max.x;

        return somePoint;
    }

    private Vector2 GetRandomPointOutsideSafeArea()
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
                if (testCounter++ > 100) throw new System.Exception("no luck in random I guess (X)");
            }
            else break;
        }

        return newPoint;
    }

}
