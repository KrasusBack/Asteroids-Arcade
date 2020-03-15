using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenWrap
{
    public static Vector2 CheckAndWrap(Vector3 pos)
    {
        var newPos = pos;
        var worldToVievportPos = Camera.main.WorldToViewportPoint(pos);

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
}

