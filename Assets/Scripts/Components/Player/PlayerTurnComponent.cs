﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerTurnComponent : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        var horizontalAxisInput = Input.GetAxis("Horizontal");
        if (horizontalAxisInput == 0) return;
        _rb.rotation += GameCore.Instance.GameSettings.PlayerRotationSpeed * -horizontalAxisInput;
    }
    void Turn(float axisInput)
    {
        _rb.AddRelativeForce(Vector2.right * GameCore.Instance.GameSettings.PlayerMoveSpeed);
    }
}
