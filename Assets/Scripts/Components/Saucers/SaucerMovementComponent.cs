using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SaucerSettingsComponent))]
public class SaucerMovementComponent : MovementConponent
{
    private Saucer _saucer;
    private Vector2 direction;

    private void Start()
    {
        var someAngle = 60;
        _saucer = GetComponent<SaucerSettingsComponent>().GetSettings();
        direction = GetRandomDirection(someAngle);
    }

    private void FixedUpdate()
    {
        MoveKinematicRB(_saucer.MoveSpeed, direction);
    }

}
