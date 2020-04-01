using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyOperation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyOperation();  
    }

    private void DestroyOperation()
    {
        BeforeDestroyOperation();
        Destroy(gameObject);
    }

    /// <summary> Called right before destroying gameObject </summary>
    protected virtual void BeforeDestroyOperation () { }
}
