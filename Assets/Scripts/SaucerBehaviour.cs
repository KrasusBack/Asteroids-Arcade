using UnityEngine;

public class SaucerBehaviour : MonoBehaviour
{
    private float MoveSpeed => GameCore.Instance.GameSettings.SaucersMoveSpeed;
    private float ShootSpeed => GameCore.Instance.GameSettings.SaucerShootingSpeed;
    private GameObject BulletObj => GameCore.Instance.GameSettings.SaucerBulletPrefab;
    private GameObject PlayerShip => GameCore.Instance.PlayerShip;

    private Rigidbody2D _rigidbody2D;
    private Transform _playerShipTransform;
    private float _lastTimeShot = 0f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerShipTransform = PlayerShip.transform;
    }

    private void FixedUpdate()
    {
        ScreenWrap.CheckAndWrapAround(_rigidbody2D);

        Move();
        Shoot();
    }

    private void Shoot()
    {
        if (ShootSpeed == 0) return;
        if (Time.fixedTime - _lastTimeShot < 1 / ShootSpeed) return;
        _lastTimeShot = Time.fixedTime;

        var direction = _playerShipTransform.position - transform.position;
        var angle = Vector2.SignedAngle(Vector2.right, direction);
        var rotation = Quaternion.Euler(0, 0, angle);

        Instantiate(BulletObj, _rigidbody2D.position, rotation);
    }

    private void Move()
    {
        var newPos = _rigidbody2D.position + Vector2.right * MoveSpeed;
        _rigidbody2D.MovePosition(newPos);
    }

}
