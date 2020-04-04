using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerShootingComponent : MonoBehaviour
{
    Transform _playerShipTransform;
    Rigidbody2D _rb;

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
            yield return new WaitForSeconds(1 / GameCore.Instance.GameSettings.SaucerShootingSpeed);
        }
    }

    private void Shoot()
    {
        //if (_playerShipTransform == null) return;
        if (!GameCore.Instance.PlayerShip.activeSelf) return;
        if (GameCore.Instance.GameSettings.SaucerShootingSpeed == 0) return;

        var direction = _playerShipTransform.position - transform.position;
        var angle = Vector2.SignedAngle(Vector2.right, direction);
        var rotation = Quaternion.Euler(0, 0, angle);

        var bulletObj = GameCore.Instance.GameSettings.SaucerBulletPrefab;
        Instantiate(bulletObj, _rb.position, rotation);
    }

}
