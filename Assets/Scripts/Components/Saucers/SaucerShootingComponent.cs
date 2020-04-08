using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerShootingComponent : MonoBehaviour
{
    private Transform _playerShipTransform;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerShipTransform = GameCore.Instance.PlayerShip.transform;

        StartCoroutine(PeriodicShoot());
    }

    private IEnumerator PeriodicShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(1 / GameCore.Instance.SaucersSettings.ShootingSpeed);
        }
    }

    private void Shoot()
    {
        if (!GameCore.Instance.PlayerShip.activeSelf) return;
        if (GameCore.Instance.SaucersSettings.ShootingSpeed == 0) return;

        var direction = _playerShipTransform.position - transform.position;
        var angle = Vector2.SignedAngle(Vector2.right, direction);
        var rotation = Quaternion.Euler(0, 0, angle);

        var bulletObj = GameCore.Instance.SaucersSettings.BulletPrefab;
        Instantiate(bulletObj, _rb.position, rotation);
    }

}
