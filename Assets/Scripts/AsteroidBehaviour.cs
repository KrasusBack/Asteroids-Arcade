using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 1f;
    [SerializeField]
    private float maxSpeed = 5f;
    [SerializeField]
    private GameObject[] asteroidPrefabs;
    [SerializeField]
    private float asteroidScaleMedium = 0.5f;
    [SerializeField]
    private float asteroidScaleSmall = 0.25f;

    public enum AsteroidSize { Large, Medium, Small };

    private Vector2 _velocityVector;
    private Rigidbody2D _rigidbody2D;
    private AsteroidColliderBehaviour[] _asteroidColliderBehaviours;
    private float _speed;
    private AsteroidSize _asteroidSize = AsteroidSize.Large;

    // Start is called before the first frame update
    void Start()
    {
        _asteroidColliderBehaviours = GetComponentsInChildren<AsteroidColliderBehaviour>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _velocityVector = MathfExtentions.DegreeToVector2(Random.Range(0, 360));
        _speed = Random.Range(minSpeed, maxSpeed);
    }

    private void CheckCollisions()
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

    private void ShatterAsteroid()
    {
        if (_asteroidSize == AsteroidSize.Small) return;
        SpawnNewAsteroids();
    }

    private void SpawnNewAsteroids ()
    {
        for (var i = 0; i < 2; ++i)
        {
            var variation = Random.Range(0, asteroidPrefabs.Length - 1);
            var newAsteroid = Instantiate(asteroidPrefabs[variation], _rigidbody2D.position, transform.rotation);

            AsteroidSize newAsteroidSize = GetPreviousSize(_asteroidSize);
            newAsteroid.GetComponent<AsteroidBehaviour>().SetSize(newAsteroidSize);
        }
    }

    private void Move()
    {
        var newPos = _rigidbody2D.position + _velocityVector * _speed;
        _rigidbody2D.MovePosition(newPos);
    }

    //Returns Small Size if there is no previous
    private AsteroidSize GetPreviousSize (AsteroidSize size)
    {
        switch (size)
        {
            case AsteroidSize.Large:
                    return AsteroidSize.Medium;
            case AsteroidSize.Medium:
                return AsteroidSize.Small;
        }
        return AsteroidSize.Small;
    }

    public void SetSize(AsteroidSize size)
    {
        _asteroidSize = size;

        if (size == AsteroidSize.Medium) { transform.localScale = asteroidScaleMedium*Vector3.one; return; }
        if (size == AsteroidSize.Small) transform.localScale = asteroidScaleSmall*Vector3.one;
    }

    private void Destroy()
    {
        ShatterAsteroid();
        Destroy(gameObject);
    }

}
