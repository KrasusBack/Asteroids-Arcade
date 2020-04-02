using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperspaceHandler : MonoBehaviour
{
    private bool _readyToGo = true;

    private IEnumerator GoIntoHyperSpace()
    {
        print("Going into Hyperspace...");
        _readyToGo = false;
        GameCore.Instance.PlayerShip.SetActive(false);
        yield return new WaitForSeconds(GameCore.Instance.GameSettings.TimeInHyperSpace);

        GameCore.Instance.PlayerShip.SetActive(true);
        ChooseNewPosition();
        print("... and appear from Hyperspace!");
        yield return new WaitForSeconds(GameCore.Instance.GameSettings.HyperSpaceCooldown);
        _readyToGo = true;
    }

    private void ChooseNewPosition()
    {
        var minPos = 0.00f;
        var maxPos = 1.00f;

        var origZPos = transform.position.z;
        var newPos = new Vector3(Random.Range(minPos, maxPos), Random.Range(minPos, maxPos), Camera.main.transform.position.z);
        newPos = Camera.main.ViewportToWorldPoint(newPos);
        newPos.z = origZPos;

        GetComponent<Rigidbody2D>().position = newPos;
    }
}
