using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaucerSettingsComponent.SaucerType;

[RequireComponent(typeof(Destroyable))]
public class PointsGiverComponent : MonoBehaviour
{
    private int _pointsAfterDestroy = 0;

    private void Start()
    {
        GetComponent<Destroyable>().DestroyableGonnaDestroyObject+= CheckAndGivePoints;
        SetPointsAfterDestroy();
    }

    private void SetPointsAfterDestroy()
    {
        switch (gameObject.tag)
        {
            case "Asteroids":
                _pointsAfterDestroy = GetAsteroidPointsInfo();
                break;

            case "Enemies":
                var saucerType = GetComponent<SaucerSettingsComponent>().Type;
                switch(saucerType)
                {
                    case Small:
                        _pointsAfterDestroy = GameCore.Instance.PointsSettings.SmallSaucerPoints;
                        break;
                    case Big:
                        _pointsAfterDestroy = GameCore.Instance.PointsSettings.BigSaucerPoints;
                        break;
                    default:
                        throw new System.IndexOutOfRangeException($"There is no Saucer type such as {saucerType}");
                }
                break;
        }
    }

    private int GetAsteroidPointsInfo()
    {
        var size = GetComponent<AsteroidPropertiesComponent>()?.AsteroidSize;
        if (size == null)
        {
            throw new System.Exception(GetType().ToString() + ": wrong tag on Asteroid object " + gameObject.name);
        }

        switch (size)
        {
            case Asteroid.SizeType.Large:
                return GameCore.Instance.PointsSettings.LargeAsteroidPoints;
            case Asteroid.SizeType.Medium:
                return GameCore.Instance.PointsSettings.MediumAsteroidPoints;
            default:
                return GameCore.Instance.PointsSettings.SmallAsteroidPoints;
        }
    }

    /// <summary>
    /// Checks if player caused destroying of an object and increased score for it
    /// </summary>
    private void CheckAndGivePoints(GameObject objCausedDestroying)
    {
        if (objCausedDestroying?.tag != "Player") return;
        GameCore.Instance.AddPointsToScore(_pointsAfterDestroy);
    }

}
