using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootingBullet
{
    float BulletSpeed { get; }
    float BulletTravelDistance { get; }
}
