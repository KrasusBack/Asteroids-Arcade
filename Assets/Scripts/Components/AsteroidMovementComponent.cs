using UnityEngine;

public class AsteroidMovementComponent : MovementConponentBase
{
    private Vector2 _velocityVector;
    private AsteroidBehaviour.AsteroidSize _asteroidSize;

    private void Awake()
    {
        _velocityVector = MathfExtentions.DegreeToVector2(Random.Range(0, 360));
        _asteroidSize = GetComponent<AsteroidBehaviour>().Size;
    }

    private void FixedUpdate()
    {
        var speed = AsteroidBehaviour.FetchAsteroidSettings(_asteroidSize).speed;
        MoveKinematicRB(speed, _velocityVector);
    }
}
