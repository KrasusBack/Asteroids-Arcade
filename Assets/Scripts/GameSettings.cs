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

    public GameObject RandomAsteroidPrefab
    {
        get
        {
            var variation = Random.Range(0, asteroidPrefabs.Length - 1);
            return asteroidPrefabs[variation];
        } 
    }
    #endregion

    #region PlayerShip

    public GameObject PlayerBulletPrefab
    {
        get => playerBulletPrefab;
    }

    public float PlayerMoveSpeed
    {
        get => playerMoveSpeed;
    }

    public float PlayerRotationSpeed
    {
        get => playerRotationSpeed;
    }

    public float PlayersBulletSpeed
    {
        get => playersBulletSpeed;
    }

    public float PlayerBulletTravelDistance
    {
        get => playerBulletTravelDistance;
    }

    #endregion

    #region Saucers

    public GameObject SaucerBulletPrefab
    {
        get => saucerBulletPrefab;
    }

    public float SaucersMoveSpeed 
    {
        get => saucersMoveSpeed;
    }

    public float SaucersBulletSpeed 
    {
        get => saucersBulletSpeed;
    }

    public float SaucerBulletTravelDistance
    {
        get => saucerBulletTravelDistance;
    }

    public float SaucerShootingSpeed
    {
        get => saucerShootingSpeed;
    }

    #endregion
}
