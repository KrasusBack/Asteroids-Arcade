using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerHyperSpaceComponent : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(GameCore.Instance.References.InputSettings.HyperSpaceKey))
        {
            GameCore.Instance.TravelToHyperSpace();
        }
    }
}
