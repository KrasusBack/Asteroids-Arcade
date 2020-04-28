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

        //Screen wrap - obj will appear from other side of the screen if is goes beyond viewport space 
        if (rb.position.x < cameraPos.x - screenBounds.x || rb.position.x >= cameraPos.x + screenBounds.x)
        {
            newPos.x = -newPos.x;
        }
        if (rb.position.y < cameraPos.y - screenBounds.y || rb.position.y >= cameraPos.y + screenBounds.y)
        {
            newPos.y = -newPos.y;
        }

        //Check if pos has changed
        if (newPos.x != rb.position.x || newPos.y != rb.position.y)
        {
            var offset = 0.001f;

            //Return object from outside of the screen if it stuck/flew away somehow
            if (newPos.x < cameraPos.x - screenBounds.x)
            {
                newPos.x = cameraPos.x - screenBounds.x + offset;
            }
            else if (newPos.x >= cameraPos.x + screenBounds.x)
            {
                newPos.x = cameraPos.x + screenBounds.x - offset;
            }

            if (newPos.y < cameraPos.y - screenBounds.y)
            {
                newPos.y = cameraPos.y - screenBounds.y + offset;
            } else if (newPos.y >= cameraPos.y + screenBounds.y)
            {
                newPos.y = cameraPos.y + screenBounds.y - offset;
            }

            rb.position = newPos;
        }
    }
}
