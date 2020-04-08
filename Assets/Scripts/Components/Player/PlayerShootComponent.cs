using UnityEngine;

public sealed class PlayerShootComponent : MonoBehaviour
{
    [SerializeField]
    private KeyCode shootKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(GameCore.Instance.GameSettings.FireKey)) Shoot();
    }

    void Shoot()
    {
        //var offsetFromTheShip = 0.5f;
        var posOffset = transform.position; //+ ((_boxCollider2D.size.x / 2 + offsetFromTheShip) * MathfExtentions.DegreeToVector2(transform.eulerAngles.z));

        Instantiate(GameCore.Instance.GameSettings.PlayerBulletPrefab, posOffset, transform.rotation);
    }
}
