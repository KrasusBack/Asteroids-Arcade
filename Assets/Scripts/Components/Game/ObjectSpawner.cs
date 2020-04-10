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

    private void Start()
    {
        GameCore.Instance.GameIsStarted += SpawnObjectsOutsideSafeArea;
    }

    private void SpawnObjectsOutsideSafeArea()
    {
        var asteroidsAmount = GameCore.Instance.LevelSettings.BaseAsteroidAmount + GameCore.Instance.LevelSettings.AdditionalAsteroidsEachStage * (GameCore.Instance.CurrentStage-1);
        for (var i = 0; i < asteroidsAmount; i++)
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

}
