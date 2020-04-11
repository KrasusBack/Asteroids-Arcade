using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaucerShootingComponent : ShootingComponentBase
{
    private SaucerStats _shotingSettings;

    private void Start()
    {
        _shotingSettings = GetComponent<SaucerSettingsComponent>().GetSettings();
        StartCoroutine(PeriodicShoot());
    }

    private IEnumerator PeriodicShoot()
    {
        while (true)
        {
            //Shoot in direction of player's ship if it's alive (active)
            if (GameCore.Instance.PlayerShip.activeSelf)
            {
                var direction = GameCore.Instance.PlayerShip.transform.position - transform.position;
                var bullet = Shoot(direction, _shotingSettings.BulletPrefab);
                //Set behaviour of bullet based on shooter
                SetBulletSettings(bullet);
            }
            yield return new WaitForSeconds(1 / _shotingSettings.ShootingSpeed);
        }
    }
    
}
