using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootingStats
{
    float ShootingSpeed { get; }
    //probability to shoot straight in target direction (0 to 1)
    float ShootingAccuracy { get; }
    //bullet max deviation from target direction 
    float SpreadAngle { get; }
}
