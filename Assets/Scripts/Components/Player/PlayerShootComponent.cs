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
        //Set shooter to set behaviour of bullet based on shooter
        SetBulletSettings(bullet);
    }

    protected override void SetBulletSettings(GameObject bullet)
    {
        bullet.GetComponent<BulletSettingsComponent>().Shooter = gameObject;
    }
}
