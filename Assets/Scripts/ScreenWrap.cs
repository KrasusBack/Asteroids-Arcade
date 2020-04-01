using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenWrap
{
    public static void CheckAndWrapAround(Rigidbody2D rigidbody2D)
    {
        var newPos = WrapAround(rigidbody2D);
        if (newPos.x != rigidbody2D.position.x || newPos.y != rigidbody2D.position.y) rigidbody2D.position = newPos;
    }

    private static Vector2 WrapAround (Rigidbody2D rigidbody2D)
    {
        var newPos = new Vector2(rigidbody2D.position.x, rigidbody2D.position.y);
        var worldToViewportPos = Camera.main.WorldToViewportPoint(rigidbody2D.position);

        if (worldToViewportPos.x < 0 || worldToViewportPos.x >= 1)
        {
            newPos.x = -newPos.x;
        }
        if (worldToViewportPos.y < 0 || worldToViewportPos.y >= 1)
        {
            newPos.y = -newPos.y;
        }

        return newPos;
    }
}

