using UnityEngine;
using System.Collections;

public sealed class PlayerShootingComponent : ShootingComponent
{
    private bool canShootNow = true;
    void Update()
    {
        //basic verstion: 1 shot per push without cooldown
        //if (Input.GetKeyDown(GameCore.Instance.InputSettings.FireKey)) Shoot();

        //periodic shoot implementation
        if (Input.GetKey(GameCore.Instance.References.InputSettings.FireKey) && canShootNow)
        {
            Shoot();
            StartCoroutine(WaitForNextShot());
        }
    }

    private IEnumerator WaitForNextShot()
    {
        canShootNow = false;
        yield return new WaitForSeconds(1 / GameCore.Instance.References.PlayerShipSettings.ShootingSpeed);
        canShootNow = true;
    }

    void Shoot()
    {
        var bullet = Instantiate(GameCore.Instance.References.PlayerShipSettings.BulletPrefab, transform.position, transform.rotation);
        //Set behaviour of bullet based on shooter
        SetBulletSettings(bullet);
        InvokeShotEvent();
    }

    private void OnDisable()
    {
        canShootNow = true;
    }

}
