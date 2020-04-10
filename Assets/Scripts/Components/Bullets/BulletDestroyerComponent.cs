using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BulletDestroyerComponent : Destroyable
{
    // Start is called before the first frame update
    protected override void Start()
    {
        IBullet bulletStats = GetComponent<BulletSettingsComponent>().ShootingStats;
        var lifeTime = bulletStats.BulletTravelDistance / bulletStats.BulletSpeed;
        Destroy(gameObject, lifeTime);
    }
    //to prevent subtract from objCounters
    protected override void OnDestroy() { }
}
