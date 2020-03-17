using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidColliderBehaviour : MonoBehaviour
{
    private bool _collidedThisFrame = false;

    public bool Сollided ()
    {
        return _collidedThisFrame;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collidedThisFrame = true;
    }
}
