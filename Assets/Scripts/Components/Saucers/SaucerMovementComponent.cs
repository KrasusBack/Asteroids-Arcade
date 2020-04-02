using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SaucerMovementComponent : MovementConponentBase
{
    void FixedUpdate()
    {
        MoveKinematicRB(GameCore.Instance.GameSettings.SaucersMoveSpeed, Vector2.right);
    }
}
