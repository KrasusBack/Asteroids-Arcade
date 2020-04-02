using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHyperSpaceComponent : MonoBehaviour
{
    [SerializeField]
    private KeyCode hyperSpaceKey = KeyCode.LeftShift;

    private Rigidbody2D _rb;
    private GameObject _playerShip;
    private bool _readyToGo = true;

    private void Start()
    {
        _playerShip = gameObject;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!_readyToGo) return;
        if (Input.GetKeyDown(hyperSpaceKey))
        {
            StartCoroutine(GoIntoHyperSpace());
        }
    }



    //наладить с помощью корутинов
    //добавить возможность появления внутри астероида (еще одна настройка - шанс спавна внутри астероида)
}
