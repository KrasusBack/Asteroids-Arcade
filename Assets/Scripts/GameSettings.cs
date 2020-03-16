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
}
