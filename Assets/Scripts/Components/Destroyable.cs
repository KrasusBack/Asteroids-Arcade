using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private float _hitFrame = 0;

    protected virtual void Start()
    {
        DoInStart();
        GameCore.Instance.IncreaseDestroyableObjectsCounter();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckAndHandleCollision(collision?.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckAndHandleCollision(collision?.attachedRigidbody?.gameObject);
    }

    /// <summary> Calls DestroyableGoingToDestroyObject and DestroyOperation. 
    /// Can be only called once per Time.fixedTime </summary>
    private void CheckAndHandleCollision(GameObject objCausedDestroying)
    {
        if (objCausedDestroying == null) return;
        if (Time.fixedTime == _hitFrame) return;
        _hitFrame = Time.fixedTime;

        DestroyableGonnaDestroyObject?.Invoke(objCausedDestroying);
        DestroyOperation();
    }

    protected virtual void DestroyOperation()
    {
        BeforeDestroyOperation();
        Destroy(gameObject);
    }

    protected virtual void OnDestroy()
    {
        GameCore.Instance.DecreaseDestroyableObjectsCounter();
    }

    /// <summary> Called in Start after Destroyable initialisation </summary>
    protected virtual void DoInStart() { }
    /// <summary> Called right before destroying gameObject in DestroyOperation </summary>
    protected virtual void BeforeDestroyOperation() { }

    public delegate void DoBeforeDestroyByDestroyableHandler(GameObject objCausedDestroying);
    public event DoBeforeDestroyByDestroyableHandler DestroyableGonnaDestroyObject;
}
