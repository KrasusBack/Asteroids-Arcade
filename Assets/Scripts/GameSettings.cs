using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]

public class GameSettings : ScriptableObject
{
    [Header("Asteroids")]
    [SerializeField]
    private GameObject[] asteroidPrefabs;
    [SerializeField]
    private Asteroid largeAsteroid;
    [SerializeField]
    private Asteroid mediumAsteroid;
    [SerializeField]
    private Asteroid smallAsteroid;

    [Header("PlayerShipSettings")]
    [SerializeField]
    private float playerMoveSpeed;
    [SerializeField]
    private float playerRotationSpeed;
    [SerializeField]
    private float playersBulletSpeed;
    [SerializeField]
    private float playerBulletTravelDistance;

    #region Asteroids
    [System.Serializable]
    public struct Asteroid
    {
        public float speed;
        public float sizeScale;
    }

    public Asteroid LargeAsteroid()
    {
        return largeAsteroid;
    }

    public Asteroid MediumAsteroid()
    {
        return mediumAsteroid;
    }

    public Asteroid SmallAsteroid()
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
}
