using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaucerShootingComponentBase : MonoBehaviour
{
    protected abstract void Start();

    protected void Shoot(Vector2 direction)
    {
        if (!GameCore.Instance.PlayerShip.activeSelf) return;

        var angle = Vector2.SignedAngle(Vector2.right, direction);
        var rotation = Quaternion.Euler(0, 0, angle);

        var bulletObj = GameCore.Instance.SaucersSettings.BulletPrefab;
        Instantiate(bulletObj, transform.position, rotation);
    }

}
