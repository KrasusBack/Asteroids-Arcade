using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 1f;
    [SerializeField]
    private float travelDistance = 100f;
    
    private Rigidbody2D _rigidbody2D;
    private float _distanceCovered = 0f;

    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ScreenWrap.CheckAndWrapAround(_rigidbody2D);

        Travel();      
    }

    private void Travel ()
    {
        var speed = bulletSpeed * Time.deltaTime;
        _distanceCovered += speed;
        if (_distanceCovered >= travelDistance)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 newPos = _rigidbody2D.position + MathfExtentions.DegreeToVector2(_rigidbody2D.rotation) * speed;
        _rigidbody2D.MovePosition(newPos);
    }
}
