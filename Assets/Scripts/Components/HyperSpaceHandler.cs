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

    private void SetExitPositionFromHyperSpace(Transform objTransform)
    {
        Vector3 newPos;

        if (Random.value > GameCore.Instance.GameSettings.ChanceToAppearInsideAsteroid)
        {
            newPos = GetNewRandomPositionOnScreen(objTransform.position.z);
        }
        else
        {
            var someAsteroid = GameObject.FindWithTag("Asteroids");
            newPos = (someAsteroid == null) ? GetNewRandomPositionOnScreen(objTransform.position.z) : someAsteroid.transform.position;
        }

        objTransform.position = newPos;
    }

    private Vector3 GetNewRandomPositionOnScreen(float zPosition)
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
