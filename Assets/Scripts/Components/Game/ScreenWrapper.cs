using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    private Rigidbody2D rb;

    private static Vector2 screenBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (screenBounds == Vector2.zero)
            SetScreenBounds();
    }

    private void FixedUpdate()
    {
        WrapAround();
    }

    private static void SetScreenBounds()
    {
        if (!Camera.main.orthographic) throw new UnityException("ScreenBoundsSetter: Camera should be orthographic");

        var topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        var bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

        screenBounds = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y) / 2;
    }

    private void WrapAround()
    {
        var newPos = new Vector2(rb.position.x, rb.position.y);
        Vector2 cameraPos = Camera.main.transform.position;

        if (rb.position.x < cameraPos.x - screenBounds.x || rb.position.x >= cameraPos.x + screenBounds.x)
        {
            newPos.x = -newPos.x;
        }
        if (rb.position.y < cameraPos.y - screenBounds.y || rb.position.y >= cameraPos.y + screenBounds.y)
        {
            newPos.y = -newPos.y;
        }

        if (newPos.x != rb.position.x || newPos.y != rb.position.y)
        {
            rb.position = newPos;
        }
    }
}
