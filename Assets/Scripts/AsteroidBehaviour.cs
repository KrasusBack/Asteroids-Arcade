using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 1f;
    [SerializeField]
    private float maxSpeed = 5f;

    private Vector2 _velocityVector;
    private Rigidbody2D _rigidbody2D;
    private AsteroidColliderBehaviour[] _asteroidColliderBehaviours;
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _asteroidColliderBehaviours = GetComponentsInChildren<AsteroidColliderBehaviour>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _velocityVector = MathfExtentions.DegreeToVector2(Random.Range(0, 360));
        _speed = Random.Range(minSpeed, maxSpeed);
    }

    private void CheckCollisions ()
    {
        foreach (AsteroidColliderBehaviour asteroidColliderBehaviour in _asteroidColliderBehaviours)
        {
            if (asteroidColliderBehaviour.СollidedThisFrame())
            {
                Destroy();
                return;
            }
        }
    }

    private void FixedUpdate()
    {
        ScreenWrap.CheckAndWrapAround(_rigidbody2D);

        CheckCollisions();
        Move();   
    }

    private void Move ()
    {
        var newPos = _rigidbody2D.position + _velocityVector * _speed;
        _rigidbody2D.MovePosition(newPos);
    }

    private void Destroy ()
    {
        Destroy(gameObject);
    }

}
