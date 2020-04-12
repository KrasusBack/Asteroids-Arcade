using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShipSettings", menuName = "ScriptableObjects/PlayerShipSettings", order = 4)]

public class PlayerShipSettings : ScriptableObject, IBullet
{
    [Header("General")]
    [SerializeField, Min(0)]
    private int startingLifesAmount = 3;

    [Header("Movement")]
    [SerializeField, Min(0)]
    private float moveSpeed = 50;
    [SerializeField, Min(0)]
    private float rotationSpeed = 3;

    [Header("Shooting")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField, Min(0)]
    private float bulletSpeed = 1;
    [SerializeField, Min(0)]
    private float bulletTravelDistance = 2;
    [SerializeField, Min(0)]
    private float shootingSpeed = 3.33f;
    //(if there is more shootingSpeed realated stats you should add IShootingStats)

    [Header("HyperSpace")]
    [SerializeField, Min(0)]
    private float hyperSpaceCooldown = 1;
    [SerializeField, Min(0)]
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
    public float ShootingSpeed
    {
        get => shootingSpeed;
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

    #endregion
}


