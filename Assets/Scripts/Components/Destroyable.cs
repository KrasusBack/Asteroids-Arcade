using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(name + " - OnTriggerEnter2D: " + collision.gameObject.name);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(name + " - OnTriggerEnter2D: " + collision.name);
        Destroy(gameObject);
    }

}
