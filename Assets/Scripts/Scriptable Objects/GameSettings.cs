using UnityEngine;
using static Asteroid;

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
    [SerializeField, Space(10)]
    private float hyperSpaceCooldown = 1;
    [SerializeField]
    private float timeInHyperSpace = 1;
    [SerializeField, Range(0,1)]
    private float ChanceToAppearInsideAsteroid = 1/6;

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

    public float HyperSpaceCooldown
    {
        get => hyperSpaceCooldown;
    }
    
    public float TimeInHyperSpace
    {
        get => timeInHyperSpace;
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
