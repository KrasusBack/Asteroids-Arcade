using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingComponent : MonoBehaviour
{
    /// <summary>
    /// Basic shoot method
    /// </summary>
    /// <param name="direction"> direction of bullets travel</param>
    /// <param name="bulletObj"> bullet prefab</param>
    /// <returns>Returns created bullet object</returns>
    protected GameObject Shoot(Vector2 direction, GameObject bulletObj)
    {
        var angle = Vector2.SignedAngle(Vector2.right, direction);
        var rotation = Quaternion.Euler(0, 0, angle);
        
        Shot?.Invoke();
        return Instantiate(bulletObj, transform.position, rotation);
    }

    protected void SetBulletSettings(GameObject bullet)
    {
        var settings = bullet.AddComponent<BulletSettingsComponent>();
        settings.Shooter = gameObject;
    }

    protected void InvokeShotEvent()
    {
        Shot?.Invoke();
    }
    
    public delegate void ShootingHandler();
    public event ShootingHandler Shot;
}
