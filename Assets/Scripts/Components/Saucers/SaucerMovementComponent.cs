using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SaucerSettingsComponent))]
public class SaucerMovementComponent : MovementConponentBase
{
    SaucerStats stats;

    private void Start()
    {
        stats = GetComponent<SaucerSettingsComponent>().GetSettings();
    }

    void FixedUpdate()
    {
        MoveKinematicRB(stats.MoveSpeed, Vector2.right);
    }
}
