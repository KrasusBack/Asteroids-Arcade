using UnityEngine;

[CreateAssetMenu(fileName = "SaucersSettings", menuName = "ScriptableObjects/SaucersSettings", order = 3)]

public class SaucersSettings : ScriptableObject
{
    [Header("Shooting")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField, Min(0)]
    private float moveSpeed = 40;
    [SerializeField, Min(0)]
    private float bulletSpeed = 1;
    [SerializeField, Min(0)]
    private float bulletTravelDistance = 2;
    [SerializeField, Min(0)]
    private float shootingSpeed = 0.8f;

    #region PublicGetters

    public GameObject BulletPrefab
    {
        get => bulletPrefab;
    }

    public float MoveSpeed
    {
        get => moveSpeed;
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

    #endregion
}

