using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidColliderBehaviour : MonoBehaviour
{
    private bool _collided = false;

    public bool Сollided ()
    {
        return _collided;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collided = true;
    }
}
