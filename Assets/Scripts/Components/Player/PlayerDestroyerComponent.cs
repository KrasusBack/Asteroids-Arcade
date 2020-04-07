using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerDestroyerComponent : Destroyable
{
    //Empty methods to prevent additional checks from Destroyable
    private void Start() { }
    private void OnDestroy() { }

    protected override void DestroyOperation()
    {
        GameCore.Instance.HandlePlayerDeath();
    }
}
