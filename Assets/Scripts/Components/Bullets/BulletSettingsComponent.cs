using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSettingsComponent : MonoBehaviour
{
    /// <summary>
    /// Change bullet object tag to change bullet settings
    /// </summary>
    /// <param name="tag"> Shooter's tag</param>
    public void SetShooter(string tag)
    {
        this.tag = tag;
    }

    IBullet shootingStats;
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
