using UnityEngine;

public sealed class PlayerMovementComponent : MovementComponent, IMoving
{
    [SerializeField]
    private SpriteRenderer thrustFlameRenderer;

    public bool Moving { get; private set; }  = false;

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            MoveDynamicRB(GameCore.Instance.PlayerShipSettings.MoveSpeed, Vector2.right);
            Moving = true;
            thrustFlameRenderer.enabled = true;
            return;
        }
        Moving = false;
        thrustFlameRenderer.enabled = false;            
    }
}
