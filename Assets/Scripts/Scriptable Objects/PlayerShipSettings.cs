using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShipSettings", menuName = "ScriptableObjects/PlayerShipSettings", order = 4)]

public class PlayerShipSettings : ScriptableObject
{
    [Header("General")]
    [SerializeField]
    private int startingLifesAmount = 3;
    [SerializeField, Range(0, 10)]
    private float delayBeforeRespawn = 1;

    [Header("Movement")]
    [SerializeField]
    private float playerMoveSpeed = 15;
    [SerializeField]
    private float playerRotationSpeed = 3;

    [Header("Shooting")]
    [SerializeField]
    private GameObject playerBulletPrefab;
    [SerializeField]
    private float playersBulletSpeed = 1;
    [SerializeField]
    private float playerBulletTravelDistance = 100;

    [Header("HyperSpace")]
    [SerializeField]
    private float hyperSpaceCooldown = 1;
    [SerializeField]
    private float timeInHyperSpace = 1;
    [SerializeField, Range(0, 1)]
    private float chanceToAppearInsideAsteroid = 0.167f;

    #region Public Getters

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
    public float ChanceToAppearInsideAsteroid
    {
        get => chanceToAppearInsideAsteroid;
    }

    public int StartingLifesAmount
    {
        get => startingLifesAmount;
    }

    public float DelayBeforeRespawn
    {
        get => delayBeforeRespawn;
    }

    #endregion
}


