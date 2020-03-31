using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveComponent : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();     
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0) Move();
    }

    private void Move()
    {
        _rb.AddRelativeForce(Vector2.right * GameCore.Instance.GameSettings.PlayerMoveSpeed);
    }
}
