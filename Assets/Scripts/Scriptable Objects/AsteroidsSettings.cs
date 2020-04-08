using UnityEngine;
using static Asteroid;

[CreateAssetMenu(fileName = "AsteroidsSettings", menuName = "ScriptableObjects/AsteroidsSettings", order = 2)]

public class AsteroidsSettings : ScriptableObject
{
    [SerializeField]
    private GameObject[] asteroidPrefabs;
    [SerializeField]
    private AsteroidProperties largeAsteroid;
    [SerializeField]
    private AsteroidProperties mediumAsteroid;
    [SerializeField]
    private AsteroidProperties smallAsteroid;

    #region Public Getters
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
            var variation = Random.Range(0, asteroidPrefabs.Length - 1);
            return asteroidPrefabs[variation];
        }
    }
    #endregion
}
