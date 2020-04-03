using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHyperSpaceComponent : MonoBehaviour
{
    [SerializeField]
    private KeyCode hyperSpaceKey = KeyCode.LeftShift;

    private void Update()
    {
        if (Input.GetKeyDown(hyperSpaceKey))
        {
            GameCore.Instance.TravelToHyperSpace();
        }
    }
}
