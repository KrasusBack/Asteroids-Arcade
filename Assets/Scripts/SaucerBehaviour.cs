using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerBehaviour : MonoBehaviour
{
    private float MoveSpeed => GameCore.GetInstance().GameSettings().SaucersMoveSpeed();
    private float ShootSpeed => GameCore.GetInstance().GameSettings().SaucerShootingSpeed();
    private GameObject BulletObj => GameCore.GetInstance().GameSettings().SaucerBulletPrefab();
    private GameObject PlayerShip => GameCore.GetInstance().PlayerShip();

    private Rigidbody2D _rigidbody2D;
    private Vector2 _playerShipPos;
    private float _lastTimeShot = 0f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerShipPos = PlayerShip.transform.position;
    }

    private void FixedUpdate()
    {
        ScreenWrap.CheckAndWrapAround(_rigidbody2D);

        Move();
        Shoot();
    }

    private void Shoot()
    {
        if ((Time.fixedTime - _lastTimeShot) < ShootSpeed) return;

        var playerShipPosition = _playerShipPos;
        print(playerShipPosition);
        var shootAngle = Vector2.Angle(transform.position, playerShipPosition);
        GameObject projectileObject = Instantiate(BulletObj, _rigidbody2D.position, transform.rotation);
    }

    private void Move()
    {
        var newPos = _rigidbody2D.position + Vector2.right * MoveSpeed;
        _rigidbody2D.MovePosition(newPos);
    } 

    //private void 
}
