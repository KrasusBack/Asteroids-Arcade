using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHyperSpaceComponent : MonoBehaviour
{
    [SerializeField]
    private KeyCode hyperSpaceKey = KeyCode.LeftShift;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(hyperSpaceKey)) HyperSpace();
    }

    private void HyperSpace()
    {
        var minPos = 0.00f;
        var maxPos = 1.00f;

        var origZPos = transform.position.z;
        var newPos = new Vector3(Random.Range(minPos, maxPos), Random.Range(minPos, maxPos), Camera.main.transform.position.z);
        newPos = Camera.main.ViewportToWorldPoint(newPos);
        newPos.z = origZPos;

        _rb.position = newPos;
    }
}
