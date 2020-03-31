using UnityEngine;

public class PlayerShipMoveComponent : IMove
{
    public void Move(Rigidbody2D rb)
    {
        rb.AddRelativeForce(Vector2.right * GameCore.Instance.GameSettings.PlayerMoveSpeed);
    }
}
