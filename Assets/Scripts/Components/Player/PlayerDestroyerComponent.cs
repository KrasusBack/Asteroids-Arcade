using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyerComponent : Destroyable
{
    protected override void DestroyOperation()
    {
        GameCore.Instance.HandlePlayerDeath();
    }
}
