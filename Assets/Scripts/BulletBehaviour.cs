using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float _bulletSpeed = 1f;
    private float _travelDistance = 10f;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _bulletSpeed = GameCore.Instance.GameSettings.PlayersBulletSpeed;
        _travelDistance = GameCore.Instance.GameSettings.PlayerBulletTravelDistance;

        Destroy(gameObject, _travelDistance / _bulletSpeed);
    }

    void FixedUpdate()
    {
        ScreenWrap.CheckAndWrapAround(_rigidbody2D);
        Move();      
    }

    private void Move ()
    {
        Vector2 newPos = _rigidbody2D.position + MathfExtentions.DegreeToVector2(_rigidbody2D.rotation) * _bulletSpeed;
        _rigidbody2D.MovePosition(newPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
