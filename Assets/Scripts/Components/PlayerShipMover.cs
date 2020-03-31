using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMoveComponent : IMove
{
    public void Move(Rigidbody2D rb)
    {
        rb.AddRelativeForce(Vector2.right * GameCore.GetInstance().GameSettings().PlayerMoveSpeed());
    }
}
