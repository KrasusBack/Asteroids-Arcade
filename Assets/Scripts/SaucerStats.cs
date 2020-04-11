﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaucerStats : IBullet, IShootingStats
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField, Min(0)]
    private float moveSpeed;
    [SerializeField, Min(0)]
    private float bulletSpeed;
    [SerializeField, Min(0)]
    private float bulletTravelDistance;
    [SerializeField, Min(0.001f)]
    private float shootingSpeed;
    [SerializeField, Range(0, 1)]
    private float shootingAccuracy;
    [SerializeField, Range(0, 1)]
    private float avoidingObstaclesMastery;

    #region Public Getters

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
    public float ShootingAccuracy
    {
        get => shootingAccuracy;
    }
    public float AvoidingObstaclesMastery
    {
        get => avoidingObstaclesMastery;
    }

    #endregion
}
