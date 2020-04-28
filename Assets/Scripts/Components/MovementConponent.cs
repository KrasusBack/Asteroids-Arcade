using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MovementComponent : MonoBehaviour
{
    protected Rigidbody2D ObjectRB { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        ObjectRB = GetComponent<Rigidbody2D>();
    }

    protected void MoveDynamicRB(float speed, Vector2 direction)
    {
        ObjectRB.AddRelativeForce(direction * GameCore.Instance.References.PlayerShipSettings.MoveSpeed);
    }

    protected void MoveKinematicRB(float speed, Vector2 direction)
    {
        var newPos = ObjectRB.position + direction * speed;
        ObjectRB.MovePosition(newPos);
    }

    /// <summary>
    /// Get random direction based on angle (from -angle to angle)
    /// </summary>
    protected Vector2 GetRandomDirection (float angle)
    {
        return MathfExtentions.DegreeToVector2(Random.Range(-angle, angle));
    }
}
