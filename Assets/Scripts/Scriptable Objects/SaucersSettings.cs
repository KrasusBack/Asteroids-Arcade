using UnityEngine;

[CreateAssetMenu(fileName = "SaucersSettings", menuName = "ScriptableObjects/SaucersSettings", order = 3)]

public class SaucersSettings : ScriptableObject
{
    [Header("Shooting")]
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

    #region PublicGetters

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

