using UnityEngine;

public abstract class MovementConponentBase : MonoBehaviour
{
    protected Rigidbody2D RigidBody { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    protected void MoveDynamicRB (float speed)
    {
        RigidBody.AddRelativeForce(Vector2.right * GameCore.Instance.GameSettings.PlayerMoveSpeed);
    }

    protected void MoveKinematicRB (float speed, Vector2 direction)
    {
        var newPos = RigidBody.position + direction * speed;
        RigidBody.MovePosition(newPos);
    }
}
