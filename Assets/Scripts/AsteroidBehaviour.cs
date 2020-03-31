using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public enum AsteroidSize { Large, Medium, Small };

    private Vector2 _velocityVector;
    private Rigidbody2D _rigidbody2D;
    private AsteroidColliderBehaviour[] _asteroidColliderBehaviours;
    private float _speed = 0f;
    private AsteroidSize _asteroidSize = AsteroidSize.Large;

    // Start is called before the first frame update
    void Start()
    {
        _asteroidColliderBehaviours = GetComponentsInChildren<AsteroidColliderBehaviour>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _velocityVector = MathfExtentions.DegreeToVector2(Random.Range(0, 360));
        if (_asteroidSize == AsteroidSize.Large) SetAsteroidSettings(_asteroidSize);
        print(gameObject.name);
    }

    private void CheckCollisions()
    {
        foreach (AsteroidColliderBehaviour asteroidColliderBehaviour in _asteroidColliderBehaviours)
        {
            if (asteroidColliderBehaviour.Сollided())
            {
                DestroyAsteroid();
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

    private GameSettings.AsteroidProperties FetchAsteroidSettings(AsteroidSize asteroidSize)
    {
        switch (asteroidSize)
        {
            case AsteroidSize.Large:
                return GameCore.Instance.GameSettings.LargeAsteroid;
            case AsteroidSize.Medium:
                return GameCore.Instance.GameSettings.MediumAsteroid;
        }
        //Small
        return GameCore.Instance.GameSettings.SmallAsteroid;
    }

    private void ShatterAsteroid()
    {
        if (_asteroidSize == AsteroidSize.Small) return;
        SpawnNewAsteroids();
    }

    private void SpawnNewAsteroids()
    {
        for (var i = 0; i < 2; ++i)
        {
            var asteroidPrefab = GameCore.Instance.GameSettings.RandomAsteroidPrefab;
            var newAsteroid = Instantiate(asteroidPrefab, _rigidbody2D.position, transform.rotation);

            AsteroidSize newAsteroidSize = GetPreviousSize(_asteroidSize);
            newAsteroid.GetComponent<AsteroidBehaviour>().SetAsteroidSettings(newAsteroidSize);
        }
    }

    private void Move()
    {
        var newPos = _rigidbody2D.position + _velocityVector * _speed;
        _rigidbody2D.MovePosition(newPos);
    }

    //Returns Small Size if there is no previous
    private AsteroidSize GetPreviousSize(AsteroidSize size)
    {
        if (size == AsteroidSize.Large) return AsteroidSize.Medium;
        return AsteroidSize.Small;
    }

    public void SetAsteroidSettings(AsteroidSize size)
    {
        _asteroidSize = size;
        var asteroidSettings = FetchAsteroidSettings(size);
        transform.localScale = asteroidSettings.sizeScale * Vector3.one;
        _speed = asteroidSettings.speed;
    }

    private void DestroyAsteroid()
    {
        ShatterAsteroid();
        Destroy(gameObject);
    }

}
