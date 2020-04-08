using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SaucerMovementComponent : MovementConponentBase
{
    void FixedUpdate()
    {
        MoveKinematicRB(GameCore.Instance.SaucersSettings.MoveSpeed, Vector2.right);
    }
}
