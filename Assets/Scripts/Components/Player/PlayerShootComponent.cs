using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShootComponent : MonoBehaviour
{
    [SerializeField]
    private KeyCode shootKey = KeyCode.Space;

    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider2D;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(shootKey)) Shoot();
    }

    void Shoot()
    {
        var offsetFromTheShip = 0.5f;
        var posOffset = _rb.position + ((_boxCollider2D.size.x / 2 + offsetFromTheShip) * MathfExtentions.DegreeToVector2(transform.eulerAngles.z));

        Instantiate(GameCore.Instance.GameSettings.PlayerBulletPrefab, posOffset, transform.rotation);
    }
}
