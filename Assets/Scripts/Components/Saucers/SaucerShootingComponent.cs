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
                var direction = DirectionBasedOnAccuracy(GameCore.Instance.PlayerShip.transform.position - transform.position);
                var bullet = Shoot(direction, _shotingSettings.BulletPrefab);
                //Set behaviour of bullet based on shooter
                SetBulletSettings(bullet);
            }
            yield return new WaitForSeconds(1 / _shotingSettings.ShootingSpeed);
        }
    }

    private Vector2 DirectionBasedOnAccuracy(Vector2 direction)
    {
        var shootingSector = _shotingSettings.SpreadAngle * (1 - _shotingSettings.ShootingAccuracy);
        if (shootingSector == 0) return direction;

        var initialAngle = Vector2.SignedAngle(Vector2.right, direction);

        var newAngle = Random.Range(initialAngle - shootingSector / 2, initialAngle + shootingSector / 2);
        return MathfExtentions.DegreeToVector2(newAngle);
    }

}
