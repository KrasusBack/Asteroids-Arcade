using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class BulletMovementComponent : MovementConponentBase
{
    private float _speed = 0;

    private void Start()
    {
        SetSpeed();
    }

    private void SetSpeed()
    {
        switch(gameObject.tag)
        {
            case "Player":
                _speed = GameCore.Instance.GameSettings.PlayersBulletSpeed;
                return;
            case "Enemies":
                _speed = GameCore.Instance.GameSettings.SaucersBulletSpeed;
                return;
        }
    }

    void FixedUpdate()
    {
        var direction = MathfExtentions.DegreeToVector2(RigidBody.rotation);
        MoveKinematicRB(_speed, direction);
    }
}
