﻿using UnityEngine;

public abstract class MovementConponentBase : MonoBehaviour
{
    protected Rigidbody2D ObjectRB { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        ObjectRB = GetComponent<Rigidbody2D>();
    }

    protected void MoveDynamicRB(float speed, Vector2 direction)
    {
        ObjectRB.AddRelativeForce(direction * GameCore.Instance.PlayerShipSettings.MoveSpeed);
    }

    protected void MoveKinematicRB(float speed, Vector2 direction)
    {
        var newPos = ObjectRB.position + direction * speed;
        ObjectRB.MovePosition(newPos);
    }
}
