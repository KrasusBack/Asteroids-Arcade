using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class ScreenBoundsSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var camera = GetComponent<Camera>();
        if (!camera.orthographic) throw new UnityException("ScreenBoundsSetter: Camera should be orthographic");
        var boxCollider2D = GetComponent<BoxCollider2D>();

        boxCollider2D.offset = Vector2.zero;
        var topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        var bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));

        var size = topRight - bottomLeft;
        boxCollider2D.size = new Vector2(size.x, size.y);

        Destroy(this);
    }
}

