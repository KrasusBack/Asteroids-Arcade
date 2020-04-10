using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BigSaucerShootingComponent : SaucerShootingComponentBase
{
    protected override void Start()
    {
        StartCoroutine(PeriodicShoot());
    }

    private IEnumerator PeriodicShoot()
    {
        while (true)
        {
            Shoot(GameCore.Instance.PlayerShip.transform.position - transform.position);
            yield return new WaitForSeconds(1 / GameCore.Instance.SaucersSettings.BigSaucerStats.ShootingSpeed);
        }
    }
}
