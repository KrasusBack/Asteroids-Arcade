using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SaucerSettingsComponent))]
public class SaucerMovementComponent : MovementComponent, IMoving
{
    private Saucer _saucer;
    private Vector2 direction;

    public bool Moving { get; private set; } = true;

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
