using UnityEngine;

[CreateAssetMenu(fileName = "SaucersSettings", menuName = "ScriptableObjects/SaucersSettings", order = 3)]

public class SaucersSettings : ScriptableObject
{
    [Header("Shooting")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float moveSpeed = 40;
    [SerializeField]
    private float bulletSpeed = 1;
    [SerializeField]
    private float bulletTravelDistance = 2;
    [SerializeField]
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

