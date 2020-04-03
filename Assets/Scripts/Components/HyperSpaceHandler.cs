using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperSpaceHandler : MonoBehaviour
{
    private bool _readyToGoIntoHyperSpace = true;

    public void TravelToHyperSpace()
    {
        if (_readyToGoIntoHyperSpace)
            StartCoroutine(HyperSpace());
    }

    private IEnumerator HyperSpace()
    {
        _readyToGoIntoHyperSpace = false;
        var shipTransform = GameCore.Instance.PlayerShip.GetComponent<Transform>();
        GameCore.Instance.PlayerShip.SetActive(false);
        yield return new WaitForSeconds(GameCore.Instance.GameSettings.TimeInHyperSpace);

        SetExitPositionFromHyperSpace(shipTransform);
        GameCore.Instance.PlayerShip.SetActive(true);
        yield return new WaitForSeconds(GameCore.Instance.GameSettings.HyperSpaceCooldown);
        _readyToGoIntoHyperSpace = true;
    }

    private static void SetExitPositionFromHyperSpace(Transform objTransform)
    {
        Vector3 newPos;

        if (Random.value > GameCore.Instance.GameSettings.ChanceToAppearInsideAsteroid)
        {
            newPos = GetRandomPositionOnScreen(objTransform.position.z);
        }
        else
        {
            var someAsteroid = GameObject.FindWithTag("Asteroids");
            newPos = (someAsteroid == null) ? GetRandomPositionOnScreen(objTransform.position.z) : someAsteroid.transform.position;
        }

        objTransform.position = newPos;
    }

    private static Vector3 GetRandomPositionOnScreen(float zPosition)
    {
        var minViewportPos = 0.00f;
        var maxViewportPos = 1.00f;

        var newPos = new Vector3(Random.Range(minViewportPos, maxViewportPos),
                                 Random.Range(minViewportPos, maxViewportPos),
                                 Camera.main.transform.position.z);
        newPos = Camera.main.ViewportToWorldPoint(newPos);
        newPos.z = zPosition;

        return newPos;
    }
}
