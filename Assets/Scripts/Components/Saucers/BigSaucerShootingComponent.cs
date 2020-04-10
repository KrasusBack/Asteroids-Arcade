using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaucerShootingComponent : PeriodicShootingComponentBase
{
    protected override void Start()
    {
        StartCoroutine(PeriodicShoot());
    }

    private IEnumerator PeriodicShoot()
    {
        while (true)
        {
            //Shoot in direction of player ship if it's alive (active)
            if (GameCore.Instance.PlayerShip.activeSelf) 
                Shoot(GameCore.Instance.PlayerShip.transform.position - transform.position);
            yield return new WaitForSeconds(1 / GameCore.Instance.SaucersSettings.BigSaucerStats.ShootingSpeed);
        }
    }
}
