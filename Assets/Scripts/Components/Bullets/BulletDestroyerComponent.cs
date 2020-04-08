using System.Collections;
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
                bulletTravelDistance = GameCore.Instance.PlayerShipSettings.BulletTravelDistance;
                bulletSpeed = GameCore.Instance.PlayerShipSettings.BulletSpeed;
                break;
            case "Enemies":
                bulletTravelDistance = GameCore.Instance.SaucersSettings.BulletTravelDistance;
                bulletSpeed = GameCore.Instance.SaucersSettings.BulletSpeed;
                break;
        }

        return bulletTravelDistance/bulletSpeed;
    }

    //to prevent subtract from objCounters
    private void OnDestroy() { }
}
