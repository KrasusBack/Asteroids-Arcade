using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenWrap
{
    private static Vector2 WrapAround (Rigidbody2D rigidbody2D)
    {
        var newPos = new Vector2(rigidbody2D.position.x, rigidbody2D.position.y);
        var worldToVievportPos = Camera.main.WorldToViewportPoint(rigidbody2D.position);

        if (worldToVievportPos.x < 0 || worldToVievportPos.x > 1)
        {
            newPos.x = -newPos.x;
        }
        if (worldToVievportPos.y < 0 || worldToVievportPos.y > 1)
        {
            newPos.y = -newPos.y;
        }

        return newPos;
    }

    public static void CheckAndWrapAround(Rigidbody2D rigidbody2D)
    {
        var newPos = ScreenWrap.WrapAround(rigidbody2D);
        if (newPos.x != rigidbody2D.position.x || newPos.y != rigidbody2D.position.y) rigidbody2D.position = newPos;
    }
}

