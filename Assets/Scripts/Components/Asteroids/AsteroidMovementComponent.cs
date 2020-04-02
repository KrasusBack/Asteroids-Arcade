using UnityEngine;

public class AsteroidMovementComponent : MovementConponentBase
{
    private Vector2 _velocityVector;
    private Asteroid.SizeType _asteroidSize;

    private void Start()
    {
        _velocityVector = MathfExtentions.DegreeToVector2(Random.Range(0, 360));
        _asteroidSize = GetComponent<AsteroidSettingsComponent>().Size;
    }

    private void FixedUpdate()
    {
        var speed = Asteroid.FetchAsteroidSettings(_asteroidSize).speed;
        MoveKinematicRB(speed, _velocityVector);
    }
}
