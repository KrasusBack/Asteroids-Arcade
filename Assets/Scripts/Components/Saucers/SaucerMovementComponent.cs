using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SaucerSettingsComponent))]
public class SaucerMovementComponent : MovementConponentBase
{
    protected SaucerStats stats;

    private Vector2 direction;

    private void Start()
    {
        stats = GetComponent<SaucerSettingsComponent>().GetSettings();
        var angle = 60;
        direction = MathfExtentions.DegreeToVector2(Random.Range(-angle, angle));
    }

    private void FixedUpdate()
    {
        MoveKinematicRB(stats.MoveSpeed, direction);
    }
}
