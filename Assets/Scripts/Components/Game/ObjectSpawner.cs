using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    //For Context:
    //Safe area - area inside innerCollider
    //Outside safe area - area between innerCollider and outerCollider
    private LevelSettings levelSettings;

    [SerializeField]
    private BoxCollider2D innerCollider;
    [SerializeField]
    private BoxCollider2D outerCollider;

    private void Start()
    {
        levelSettings = GameCore.Instance.LevelSettings;

        GameCore.Instance.NewLevelStarted += SpawnLevelObjects;
        GameCore.Instance.StageCleared += StopSpawning;
    }
    /*
    private void SpawnObjectsOutsideSafeArea() //~asteroids spawn area
    {
        var asteroidsAmount = GameCore.Instance.LevelSettings.BaseAsteroidAmount + GameCore.Instance.LevelSettings.AdditionalAsteroidsEachStage * (GameCore.Instance.CurrentStage-1);
        for (var i = 0; i < asteroidsAmount; i++)
            Instantiate(GameCore.Instance.AsteroidsSettings.AsteroidBaseObject, GetRandomPointOutsideSafeArea(), Quaternion.identity);
    }
    */

    private void SpawnLevelObjects()
    {
        //asteroids
        var asteroidsAmount = levelSettings.BaseAsteroidAmount + levelSettings.AdditionalAsteroidsEachStage * (GameCore.Instance.CurrentStage - 1);
        if (asteroidsAmount > levelSettings.AsteroidsMaxAmount)
            asteroidsAmount = levelSettings.AsteroidsMaxAmount;
        for (var i = 0; i < asteroidsAmount; i++)
            SpawnAsteroid();

        //start saucer spawn timer
        StartCoroutine( saucerSpawnTimer());
    }

    private IEnumerator saucerSpawnTimer()
    {
        while(true)
        {
            var saucerSpawnTimer = GameCore.Instance.LevelSettings.SaucerSpawnTimer - (GameCore.Instance.CurrentStage - 1);
            yield return new WaitForSeconds(saucerSpawnTimer);

            //decide saucer type to spawn
            if (GameCore.Instance.CurrentStage < levelSettings.LittleSaucerFirstLevelAppearance &&
                //<не последний уровень для появления большой тарелки
                //расчитать вероятность появления большой тарелки отталкиваясь от последнего уровня для его появления и текущего уровня (~)
                
        }
    }

    private void SpawnSmallSaucer()
    {
        Instantiate(GameCore.Instance.SaucersSettings.SmallSaucer.SaucerObjPrefab, GetRandomPointOutsideSafeArea(), Quaternion.identity);
    }

    private void SpawnBigSaucer()
    {
        Instantiate(GameCore.Instance.SaucersSettings.BigSaucer.SaucerObjPrefab, GetRandomPointOutsideSafeArea(), Quaternion.identity);
    }

    private void SpawnAsteroid()
    {
        Instantiate(GameCore.Instance.AsteroidsSettings.AsteroidBaseObject, GetRandomPointOutsideSafeArea(), Quaternion.identity);
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

    private void StopSpawning()
    {
        StopAllCoroutines();
    }

}
