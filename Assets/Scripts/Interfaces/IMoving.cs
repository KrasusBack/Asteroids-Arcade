using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoving
{
    /// <summary> Defines if objects is moving right now </summary>
    bool Moving { get; }
}
