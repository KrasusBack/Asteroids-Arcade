using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private float hitFrame = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckAndDestroy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckAndDestroy();
    }

    /// <summary>
    /// Checks if there are more than one hit this frame and call DestroyOperation. Prevents more than one DestroyOperation call. 
    /// </summary>
    private void CheckAndDestroy()
    {
        if (Time.frameCount == hitFrame) return;
        hitFrame = Time.frameCount;
        DestroyOperation();
    }

    protected virtual void DestroyOperation()
    {
        BeforeDestroyOperation();
        Destroy(gameObject);
    }

    /// <summary> Called right before destroying gameObject in DestroyOperation </summary>
    protected virtual void BeforeDestroyOperation () { }
}
