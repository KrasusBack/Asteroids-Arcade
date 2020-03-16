using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    [SerializeField]
    private float movementVelocity = 15f;
    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private KeyCode hyperSpaceKey = KeyCode.LeftShift;
    [SerializeField]
    private KeyCode shootKey = KeyCode.Space;
    [SerializeField]
    private GameObject bulletPrefab;

    Rigidbody2D _rigidbody2D;
    BoxCollider2D _boxCollider2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        HyperSpaceHandler();
        ShootHandler();
        RotateHandler();
        MoveForwardHandler();

        ScreenWrap.CheckAndWrapAround(_rigidbody2D);
    }

    private void RotateHandler()
    {
        var horizontalAxisInput = Input.GetAxis("Horizontal");
        if (horizontalAxisInput == 0) return;

        _rigidbody2D.rotation += rotationSpeed * -horizontalAxisInput;
    }

    private void MoveForwardHandler()
    {
        if (Input.GetAxis("Vertical") <= 0) return;

        _rigidbody2D.AddRelativeForce(Vector2.right * movementVelocity);
    }

    private void HyperSpaceHandler()
    {
        if (!Input.GetKeyDown(hyperSpaceKey)) return;

        var minPos = 0.00f;
        var maxPos = 1.00f;

        var origZPos = transform.position.z;
        var newPos = new Vector3(Random.Range(minPos, maxPos), Random.Range(minPos, maxPos), Camera.main.transform.position.z);
        newPos = Camera.main.ViewportToWorldPoint(newPos);
        newPos.z = origZPos;

        transform.position = newPos;
    }

    private void ShootHandler()
    {
        if (!Input.GetKeyDown(shootKey)) return;

        var offsetFromTheShip = 0.5f;
        var posOffset = _rigidbody2D.position + ((_boxCollider2D.size.x / 2 + offsetFromTheShip) * MathfExtentions.DegreeToVector2(transform.eulerAngles.z));

        GameObject projectileObject = Instantiate(bulletPrefab, posOffset, transform.rotation);
    }

}
