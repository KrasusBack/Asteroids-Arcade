using UnityEngine;
using static Asteroid;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AsteroidsSettings", menuName = "ScriptableObjects/AsteroidsSettings", order = 2)]

public class AsteroidsSettings : ScriptableObject
{
    [SerializeField]
    private GameObject asteroidBaseObject;
    [SerializeField]
    private List<GameObject> asteroidPrefabs;
    [SerializeField]
    private AsteroidProperties largeAsteroid;
    [SerializeField]
    private AsteroidProperties mediumAsteroid;
    [SerializeField]
    private AsteroidProperties smallAsteroid;

    #region Public Getters

    /// <summary> Base object that will transform into certain asteroid (random by default) /// </summary>
    public GameObject AsteroidBaseObject
    {
        get => asteroidBaseObject;
    }

    public AsteroidProperties LargeAsteroid
    {
        get => largeAsteroid;
    }

    public AsteroidProperties MediumAsteroid
    {
        get => mediumAsteroid;
    }

    public AsteroidProperties SmallAsteroid
    {
        get => smallAsteroid;
    }

    public GameObject RandomAsteroid
    {
        get
        {
            var variation = Random.Range(0, asteroidPrefabs.Count);
            return asteroidPrefabs[variation];
        }
    }

    public int AsteroidPrefabsCount
    {
        get => asteroidPrefabs.Count;
    }

    public GameObject GetCertainAsteroidPrefab(int index)
    {
        return asteroidPrefabs[index];
    }

    #endregion
}
