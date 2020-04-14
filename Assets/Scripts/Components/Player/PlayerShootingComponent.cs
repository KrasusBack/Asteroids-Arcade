using UnityEngine;
using System.Collections;

public sealed class PlayerShootingComponent : ShootingComponentBase
{
    private bool canShootNow = true;
    void Update()
    {
        //basic 1 shot per push without cooldown
        //if (Input.GetKeyDown(GameCore.Instance.InputSettings.FireKey)) Shoot();

        //periodic shoot implementation
        if (Input.GetKey(GameCore.Instance.InputSettings.FireKey) && canShootNow)
        {
            Shoot();
            StartCoroutine(WaitForNextShot());
        }
    }

    private IEnumerator WaitForNextShot()
    {
        canShootNow = false;
        yield return new WaitForSeconds(1 / GameCore.Instance.PlayerShipSettings.ShootingSpeed);
        canShootNow = true;
    }

    void Shoot()
    {
        var bullet = Instantiate(GameCore.Instance.PlayerShipSettings.BulletPrefab, transform.position, transform.rotation);
        //Set behaviour of bullet based on shooter
        SetBulletSettings(bullet);
        PlayerShoot?.Invoke();
    }

    private void OnDisable()
    {
        canShootNow = true;
    }

    public delegate void PlayerShootingHandler ();
    public event PlayerShootingHandler PlayerShoot;
}
