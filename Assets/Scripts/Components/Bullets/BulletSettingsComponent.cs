using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSettingsComponent : MonoBehaviour
{
    IShootingBullet shootingStats;
    // Start is called before the first frame update
    void Start()
    {
        switch (tag)
        {
            case "Player":
                shootingStats = GameCore.Instance.PlayerShipSettings;
                break;
            case "Enemies":
                shootingStats = GetComponent<SaucerSettingsComponent>().GetStats();
                break;
        }
    }
}
