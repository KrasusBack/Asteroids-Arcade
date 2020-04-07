﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BulletDestroyerComponent : Destroyable
{
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, CalculateLifetime());
    }

    private float CalculateLifetime()
    {
        float bulletTravelDistance = 0;
        float bulletSpeed = 0;

        switch (gameObject.tag)
        {
            case "Player":
                bulletTravelDistance = GameCore.Instance.GameSettings.PlayerBulletTravelDistance;
                bulletSpeed = GameCore.Instance.GameSettings.PlayersBulletSpeed;
                break;
            case "Enemies":
                bulletTravelDistance = GameCore.Instance.GameSettings.SaucerBulletTravelDistance;
                bulletSpeed = GameCore.Instance.GameSettings.SaucersBulletSpeed;
                break;
        }

        return bulletTravelDistance/bulletSpeed;
    }

    //to prevent subtract from objCounters
    private void OnDestroy() { }
}
