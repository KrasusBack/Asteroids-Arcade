using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float _bulletSpeed = 1f;
    private float _travelDistance = 100f;
    private Rigidbody2D _rigidbody2D;
    private float _distanceCovered = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _bulletSpeed = GameCore.GetInstance().GameSettings().PlayersBulletSpeed();
        _travelDistance = GameCore.GetInstance().GameSettings().PlayerBulletTravelDistance();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ScreenWrap.CheckAndWrapAround(_rigidbody2D);
        Move();      
    }

    private void Move ()
    {
        _distanceCovered += _bulletSpeed;
        if (_distanceCovered >= _travelDistance)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 newPos = _rigidbody2D.position + MathfExtentions.DegreeToVector2(_rigidbody2D.rotation) * _bulletSpeed;
        _rigidbody2D.MovePosition(newPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
