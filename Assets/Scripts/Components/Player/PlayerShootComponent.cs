using UnityEngine;

public sealed class PlayerShootComponent : ShootingComponentBase
{
    void Update()
    {
        if (Input.GetKeyDown(GameCore.Instance.InputSettings.FireKey)) Shoot();
    }

    void Shoot()
    {
        var bullet = Instantiate(GameCore.Instance.SaucersSettings.BulletPrefab, transform.position, transform.rotation);
        //Set behaviour of bullet based on shooter
        SetBulletSettings(bullet);
    }
}
