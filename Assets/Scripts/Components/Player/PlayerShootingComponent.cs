using UnityEngine;

public sealed class PlayerShootingComponent : ShootingComponentBase
{
    void Update()
    {
        if (Input.GetKeyDown(GameCore.Instance.InputSettings.FireKey)) Shoot();
    }

    void Shoot()
    {
        var bullet = Instantiate(GameCore.Instance.PlayerShipSettings.BulletPrefab, transform.position, transform.rotation);
        //Set behaviour of bullet based on shooter
        SetBulletSettings(bullet);
    }
}
