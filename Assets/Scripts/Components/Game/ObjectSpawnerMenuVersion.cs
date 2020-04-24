using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerMenuVersion : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D innerCollider;
    [SerializeField]
    private BoxCollider2D outerCollider;
    [SerializeField]
    private SpawnInfo[] objectsToSpawnInstantly;
    [SerializeField]
    private SpawnPeriodicInfo[] objectsToSpawnPeriodically;

    [System.Serializable]
    struct SpawnInfo
    {
        [Min(1)] public int Amount;
        public GameObject ObjectPrefab;
    }

    [System.Serializable]
    struct SpawnPeriodicInfo
    {
        public SpawnInfo SpawnInfo;
        [Min(0)] public float Period;
    }

    private void Start()
    {
        SpawnInstantObjects();
        StartSpawnPeriodicObjects();
    }

    private void SpawnInstantObjects()
    {
        foreach (var info in objectsToSpawnInstantly)
        {
            for (var i = 0; i < info.Amount; i++)
            {
                SpawnObject(info.ObjectPrefab);
            }
        }
    }

    private void StartSpawnPeriodicObjects()
    {
        foreach (var info in objectsToSpawnPeriodically)
        {
            StartCoroutine(PeriodicObjectSpawn(info.Period, info.SpawnInfo.ObjectPrefab, info.SpawnInfo.Amount));
        }
    }

    private IEnumerator PeriodicObjectSpawn(float period, GameObject objectToSpawn, int amount)
    {
        while(true)
        {
            for (var i = 0; i < amount; i++)
            {
                SpawnObject(objectToSpawn);
            }
            
            if (period <= 0)
            {
                throw new System.ArgumentOutOfRangeException($"Period in PeriodicObjectSpawn for {objectToSpawn} must be > 0");
            }
            yield return new WaitForSeconds(period);
        }
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
       var spawnedObject = Instantiate(objectToSpawn, ObjectSpawner.GetRandomPointBetweenColliders(innerCollider, outerCollider), Quaternion.identity);
       //optional: get rid off spawned objects audio components'
       foreach(var audioComponent in spawnedObject.GetComponents<AudioComponent>())
        {
            Destroy(audioComponent);
        }
    }
}
