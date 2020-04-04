using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenToWorld
{
    public static Vector3 GetRandomPositionOnScreen(float objectsZPosition)
    {
        var minViewportPos = 0.00f;
        var maxViewportPos = 1.00f;

        var newPos = ViewportToWorldPoint( Random.Range(minViewportPos, maxViewportPos),
                                           Random.Range(minViewportPos, maxViewportPos));
        newPos.z = objectsZPosition;

        return newPos;
    }

    private static Vector3 ViewportToWorldPoint(float xPos, float yPos)
    {
        var point = new Vector3(xPos, yPos, Camera.main.transform.position.z);
        return Camera.main.ViewportToWorldPoint(point);
    }
}
