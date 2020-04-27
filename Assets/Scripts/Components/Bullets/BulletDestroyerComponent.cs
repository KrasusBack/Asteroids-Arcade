using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BulletDestroyerComponent : Destroyable
{
    protected override void Start()
    {
        var bulletSettings = GetComponent<BulletSettingsComponent>();
        IBullet bulletStats = bulletSettings.BulletStats;

        gameObject.layer = bulletSettings.Shooter.layer;
        var lifeTime = bulletStats.BulletTravelDistance / bulletStats.BulletSpeed;
        Destroy(gameObject, lifeTime);
    }
    //to prevent subtract from objCounters
    protected override void OnDestroy() { }
}
