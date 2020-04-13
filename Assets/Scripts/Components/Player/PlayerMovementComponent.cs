using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerMovementComponent : MovementConponentBase
{
    [SerializeField]
    private SpriteRenderer thrustFlameRenderer;

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            MoveDynamicRB(GameCore.Instance.PlayerShipSettings.MoveSpeed, Vector2.right);
            thrustFlameRenderer.enabled = true;
            return;
        }
        thrustFlameRenderer.enabled = false;            
    }
}
