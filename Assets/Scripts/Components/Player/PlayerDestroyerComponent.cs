using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerDestroyerComponent : Destroyable
{
    protected override void DestroyOperation()
    {
        GameCore.Instance.HandlePlayerDeath();
    }
}
