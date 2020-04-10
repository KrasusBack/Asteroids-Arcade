using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSettingsComponent : MonoBehaviour
{
    public GameObject Shooter { get; set; }
    public IBullet ShootingStats { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        switch (Shooter.tag)
        {
            case "Player":
                ShootingStats = GameCore.Instance.PlayerShipSettings;
                print("player bullet :" + ShootingStats.BulletSpeed + " " + ShootingStats.BulletTravelDistance);
                break;
            case "Enemies":
                ShootingStats = Shooter.GetComponent<SaucerSettingsComponent>().GetStats();
                break;
        }
    }
}
