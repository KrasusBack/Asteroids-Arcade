using UnityEngine;

public abstract class MovementConponentBase : MonoBehaviour
{
    protected Rigidbody2D ObjectRB { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        ObjectRB = GetComponent<Rigidbody2D>();
    }

    protected void MoveDynamicRB (float speed)
    {
        ObjectRB.AddRelativeForce(Vector2.right * GameCore.Instance.GameSettings.PlayerMoveSpeed);
    }

    protected void MoveKinematicRB (float speed, Vector2 direction)
    {
        var newPos = ObjectRB.position + direction * speed;
        ObjectRB.MovePosition(newPos);
    }
}
