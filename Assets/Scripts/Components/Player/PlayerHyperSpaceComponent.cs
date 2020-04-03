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

    //наладить с помощью корутинов
    //добавить возможность появления внутри астероида (еще одна настройка - шанс спавна внутри астероида)
}
