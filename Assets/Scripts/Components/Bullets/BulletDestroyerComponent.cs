using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BulletDestroyerComponent : Destroyable
{
    private float lifeTime;
    
    public BulletDestroyerComponent (float bulletTravelDistance, float bulletSpeed, string shooterTag)
    {
        lifeTime = bulletTravelDistance / bulletSpeed;
        gameObject.tag = shooterTag;
    }

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    /*
    private float CalculateLifetime()
    {
        float bulletTravelDistance = 0;
        float bulletSpeed = 100;

        switch (gameObject.tag)
        {
            case "Player":
                bulletTravelDistance = GameCore.Instance.PlayerShipSettings.BulletTravelDistance;
                bulletSpeed = GameCore.Instance.PlayerShipSettings.BulletSpeed;
                break;
            case "Enemies":
                bulletTravelDistance = GameCore.Instance.SaucersSettings.BigSaucerStats.BulletTravelDistance;
                bulletSpeed = GameCore.Instance.SaucersSettings.BigSaucerStats.BulletSpeed;
                break;
        }

        if (bulletSpeed == 0) return 0;
        return bulletTravelDistance/bulletSpeed;
    }
    */
    //to prevent subtract from objCounters
    private void OnDestroy() { }
}
