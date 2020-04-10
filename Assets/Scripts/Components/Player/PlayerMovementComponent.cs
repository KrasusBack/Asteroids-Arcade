using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerMovementComponent : MovementConponentBase
{
    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0) MoveDynamicRB(GameCore.Instance.PlayerShipSettings.MoveSpeed, Vector2.right);
    }
}
