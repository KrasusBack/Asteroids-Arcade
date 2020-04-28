using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HyperSpaceHandler : MonoBehaviour
{
    private bool _readyToGoIntoHyperSpace = true;
    private ContactFilter2D contactFilter2D;
    private Renderer shipRenderer;

    private void Start()
    {
        contactFilter2D.SetLayerMask(LayerMask.GetMask("Enemies", "Asteroids"));
        contactFilter2D.useTriggers = true;
        shipRenderer = GameCore.Instance.PlayerShip.GetComponentInChildren<Renderer>();
    }

    public void TravelToHyperSpace()
    {
        if (_readyToGoIntoHyperSpace)
            StartCoroutine(HyperSpace());
    }

    private IEnumerator HyperSpace()
    {
        _readyToGoIntoHyperSpace = false;
        var shipTransform = GameCore.Instance.PlayerShip.GetComponent<Transform>();
        GameCore.Instance.DisablePlayerShip();
        yield return new WaitForSeconds(GameCore.Instance.References.PlayerShipSettings.TimeInHyperSpace);

        SetExitPositionFromHyperSpace(shipTransform);
        GameCore.Instance.EnablePlayerShip();
        yield return new WaitForSeconds(GameCore.Instance.References.PlayerShipSettings.HyperSpaceCooldown);
        _readyToGoIntoHyperSpace = true;
    }

    private void SetExitPositionFromHyperSpace(Transform objTransform)
    {
        Vector3 newPos;

        if (Random.value > GameCore.Instance.References.PlayerShipSettings.ChanceToAppearInsideAsteroid)
        {
            int attempts = 0;
            newPos = ScreenToWorld.GetRandomPositionOnScreen(objTransform.position.z);
            while (attempts<50)
            {
                if (CheckIfNewPosIsNotOccupied(newPos)) break;
                newPos = ScreenToWorld.GetRandomPositionOnScreen(objTransform.position.z);
                attempts++;
            }
            if (!(attempts<50)) throw new System.Exception("HyperSpaceHandler: failed attempts to find free space");
        }
        else
        {
            var someAsteroid = GameObject.FindWithTag("Asteroids");
            newPos = (someAsteroid == null) ? ScreenToWorld.GetRandomPositionOnScreen(objTransform.position.z)
                                            : someAsteroid.transform.position;
        }

        objTransform.position = newPos;
    }

    private bool CheckIfNewPosIsNotOccupied(Vector2 somePos)
    {
        List<Collider2D> colliders = new List<Collider2D>();
        Physics2D.OverlapCircle(somePos, shipRenderer.bounds.max.magnitude, contactFilter2D, colliders);
        if (colliders.Count > 0) return false;

        return true;
    }
}
