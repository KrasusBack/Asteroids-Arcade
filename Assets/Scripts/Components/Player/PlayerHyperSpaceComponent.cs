using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHyperSpaceComponent : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(GameCore.Instance.GameSettings.HyperSpaceKey))
        {
            GameCore.Instance.TravelToHyperSpace();
        }
    }
}
