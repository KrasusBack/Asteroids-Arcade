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

    [SerializeField]
    private GameObject testObject;

    private void Start()
    {
        SpawnObjectsOutsideSafeArea(testObject, 30);
    }

    private void SpawnObjectsOutsideSafeArea(GameObject objectToSpawn, int amount)
    {
        for (var i = 0; i < amount; i++)
            Instantiate(objectToSpawn, GetRandomPointOutsideSafeArea(), Quaternion.identity);
    }


    private Vector2 GetRandomPointOutsideSafeArea()
    {

        Vector2 newPoint;

        var outerX = new { Min = outerCollider.bounds.min.x, Max = outerCollider.bounds.max.x };
        var outerY = new { Min = outerCollider.bounds.min.y, Max = outerCollider.bounds.max.y };
        var innerX = new { Min = innerCollider.bounds.min.x, Max = innerCollider.bounds.max.x };
        var innerY = new { Min = innerCollider.bounds.min.y, Max = innerCollider.bounds.max.y };

        /*
        //Robust approach
        //pick random point and check if it fitting
        int testCounter = 0;
        while (true)
        {
            newPoint.x = Random.Range(outerX.Min, outerX.Max);
            if (newPoint.x < innerX.Min || newPoint.x > innerX.Max) break;
            if (testCounter++ > 100) throw new System.Exception("no luck in random I guess (X)"); 
        }

        testCounter = 0;
        while (true)
        {
            newPoint.y = Random.Range(outerY.Min, outerY.Max);
            if (newPoint.y < innerY.Min || newPoint.y > innerY.Max) break;
            if (testCounter++ > 100) throw new System.Exception("no luck in random I guess (Y)");
        } */

        
        Vector2 sizeDifference = new Vector2(outerCollider.bounds.size.x - innerCollider.bounds.size.x, outerCollider.bounds.size.y - innerCollider.bounds.size.y);
        Vector2 rand = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));

        /*
        newPoint.x = outerX.Min + rand.x * sizeDifference.x;
        if (newPoint.x > innerX.Min && newPoint.x < innerX.Max)
            newPoint.x += innerCollider.bounds.size.x;

        newPoint.y = outerY.Min + rand.y * sizeDifference.y;
        if (newPoint.y > innerY.Min && newPoint.y < innerY.Max)
            newPoint.y += innerCollider.bounds.size.y;
        */
        newPoint.x = outerX.Min + rand.x * sizeDifference.x;
        newPoint.y = outerY.Min + rand.y * sizeDifference.y;
        if (newPoint.x > innerX.Min && newPoint.x < innerX.Max && newPoint.y > innerY.Min && newPoint.y < innerY.Max)
        {
            //who is closer to the farther side will be moved 
            if (innerX.Max-newPoint.x < innerY.Max - newPoint.y)
                newPoint.x += innerCollider.bounds.size.x;    
            else
                newPoint.y += innerCollider.bounds.size.y;
        }

        return newPoint;
    }

}
