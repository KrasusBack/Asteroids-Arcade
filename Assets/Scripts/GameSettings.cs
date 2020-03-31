using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]

public class GameSettings : ScriptableObject
{
    [Header("Asteroids")]
    [SerializeField]
    private GameObject[] asteroidPrefabs;
    [SerializeField]
    private AsteroidProperties largeAsteroid;
    [SerializeField]
    private AsteroidProperties mediumAsteroid;
    [SerializeField]
    private AsteroidProperties smallAsteroid;

    [Header("PlayerShipSettings")]
    [SerializeField]
    private GameObject playerBulletPrefab;
    [SerializeField]
    private float playerMoveSpeed = 15;
    [SerializeField]
    private float playerRotationSpeed = 3;
    [SerializeField]
    private float playersBulletSpeed = 1;
    [SerializeField]
    private float playerBulletTravelDistance = 100;

    [Header("Saucers")]
    [SerializeField]
    private GameObject saucerBulletPrefab;
    [SerializeField]
    private float saucersMoveSpeed = 40;
    [SerializeField]
    private float saucersBulletSpeed = 10;
    [SerializeField]
    private float saucerBulletTravelDistance = 100;
    [SerializeField]
    private float saucerShootingSpeed = 0.8f;

    #region Asteroids
    [System.Serializable]
    public struct AsteroidProperties
    {
        public float speed;
        public float sizeScale;
    }

    public AsteroidProperties LargeAsteroid()
    {
        return largeAsteroid;
    }

    public AsteroidProperties MediumAsteroid()
    {
        return mediumAsteroid;
    }

    public AsteroidProperties SmallAsteroid()
    {
        return smallAsteroid;
    }

    public GameObject GetRandomAsteroidPrefab()
    {
        var variation = Random.Range(0, asteroidPrefabs.Length - 1);
        return asteroidPrefabs[variation];
    }
    #endregion

    #region PlayerShip

    public GameObject PlayerBulletPrefab()
    {
        return playerBulletPrefab;
    }

    public float PlayerMoveSpeed()
    {
        return playerMoveSpeed;
    }

    public float PlayerRotationSpeed()
    {
        return playerRotationSpeed;
    }

    public float PlayersBulletSpeed()
    {
        return playersBulletSpeed;
    }

    public float PlayerBulletTravelDistance()
    {
        return playerBulletTravelDistance;
    }

    #endregion

    #region Saucers

    public GameObject SaucerBulletPrefab()
    {
        return saucerBulletPrefab;
    }

    public float SaucersMoveSpeed ()
    {
        return saucersMoveSpeed;
    }

    public float SaucersBulletSpeed ()
    {
        return saucersBulletSpeed;
    }

    public float SaucerBulletTravelDistance()
    {
        return saucerBulletTravelDistance;
    }

    public float SaucerShootingSpeed()
    {
        return saucerShootingSpeed;
    }

    #endregion
}
