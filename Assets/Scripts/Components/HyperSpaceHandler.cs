using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HyperSpaceHandler : MonoBehaviour
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
            newPos = ScreenToWorld.GetRandomPositionOnScreen(objTransform.position.z);
        }
        else
        {
            var someAsteroid = GameObject.FindWithTag("Asteroids");
            newPos = (someAsteroid == null) ? ScreenToWorld.GetRandomPositionOnScreen(objTransform.position.z) 
                                            : someAsteroid.transform.position;
        }

        objTransform.position = newPos;
    }  
}
