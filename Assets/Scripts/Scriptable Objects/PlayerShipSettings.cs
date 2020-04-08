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
    private float moveSpeed = 15;
    [SerializeField]
    private float rotationSpeed = 3;

    [Header("Shooting")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed = 1;
    [SerializeField]
    private float bulletTravelDistance = 100;

    [Header("HyperSpace")]
    [SerializeField]
    private float hyperSpaceCooldown = 1;
    [SerializeField]
    private float timeInHyperSpace = 1;
    [SerializeField, Range(0, 1)]
    private float chanceToAppearInsideAsteroid = 0.167f;

    #region Public Getters

    public GameObject BulletPrefab
    {
        get => bulletPrefab;
    }

    public float MoveSpeed
    {
        get => moveSpeed;
    }

    public float RotationSpeed
    {
        get => rotationSpeed;
    }

    public float BulletSpeed
    {
        get => bulletSpeed;
    }

    public float BulletTravelDistance
    {
        get => bulletTravelDistance;
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


