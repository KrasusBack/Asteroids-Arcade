using UnityEngine;

public sealed class BulletMovementComponent : MovementComponent
{
    private float Speed { get; set; } = 0;

    private void Start()
    {
        SetSpeed();
    }

    private void SetSpeed()
    {
        switch(gameObject.tag)
        {
            case "Player":
                Speed = GameCore.Instance.References.PlayerShipSettings.BulletSpeed;
                break;
            case "Enemies":
                Speed = GetComponent<BulletSettingsComponent>().BulletStats.BulletSpeed;
                break;
        }
    }

    void FixedUpdate()
    {
        var direction = MathfExtentions.DegreeToVector2(ObjectRB.rotation);
        MoveKinematicRB(Speed, direction);
    }
}
