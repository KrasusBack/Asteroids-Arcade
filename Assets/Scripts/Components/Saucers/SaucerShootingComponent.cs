using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaucerShootingComponent : ShootingComponentBase
{
    private IShootingStats _shootingStats;

    private void Start()
    {
        _shootingStats = GetComponent<SaucerSettingsComponent>().GetStats();
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
                var bullet = Shoot(direction, GameCore.Instance.SaucersSettings.BulletPrefab);
                //Set behaviour of bullet based on shooter
                SetBulletSettings(bullet);
            }
            yield return new WaitForSeconds(1 / _shootingStats.ShootingSpeed);
        }
    }
    
}
