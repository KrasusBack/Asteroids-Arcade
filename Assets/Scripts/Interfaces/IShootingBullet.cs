using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    GameObject BulletPrefab { get; }
    float BulletSpeed { get; }
    float BulletTravelDistance { get; }
}
