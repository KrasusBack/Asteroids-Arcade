using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSettingsComponent : MonoBehaviour
{
    private GameObject _shooter;

    public IBullet BulletStats { get; set; }  
    public GameObject Shooter
    {
        get => _shooter;
        set
        {
            _shooter = value;
            gameObject.tag = Shooter.tag;
            switch (gameObject.tag)
            {
                case "Player":
                    BulletStats = GameCore.Instance.References.PlayerShipSettings;
                    break;
                case "Enemies":
                    BulletStats = Shooter.GetComponent<SaucerSettingsComponent>().GetSettings();
                    break;
            }

            
        }
    }
}
