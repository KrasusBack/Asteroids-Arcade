using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private float _hitFrame = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (MoreThanOnCollisionThisFrame()) return;
        print(GetType().ToString() + ": OnCollisionEnter2D - " + name);
        HandleCollision(collision?.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MoreThanOnCollisionThisFrame()) return;
        print(GetType().ToString() + ": OnTriggerEnter2D - " + name);

        var collider = collision;
        var rb = collision.attachedRigidbody;
        var obj = collision.attachedRigidbody.gameObject;

        HandleCollision(collision.attachedRigidbody.gameObject);
    }

    /// <summary>
    /// Calls DestroyableGoingToDestroyObject and DestroyOperation.
    /// </summary>
    private void HandleCollision(GameObject objCausedDestroying)
    {
        DestroyableGoingToDestroyObject(objCausedDestroying);
        DestroyOperation();
    }

    private bool MoreThanOnCollisionThisFrame()
    {
        if (Time.fixedTime == _hitFrame) return true;
        _hitFrame = Time.fixedTime;
        return false;
    }

    protected virtual void DestroyOperation()
    {
        BeforeDestroyOperation();
        Destroy(gameObject);
    }

    /// <summary> Called right before destroying gameObject in DestroyOperation </summary>
    protected virtual void BeforeDestroyOperation() { }

    public delegate void DoBeforeDestroyByDestroyableHandler(GameObject objCausedDestroying);
    public event DoBeforeDestroyByDestroyableHandler DestroyableGoingToDestroyObject;
}
