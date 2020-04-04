using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGiverComponent : MonoBehaviour
{
    private int _pointsAfterDestroy = 0;

    private void Start()
    {
        GetComponent<Destroyable>().DestroyableGoingToDestroyObject+= CheckAndGivePoints;
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
                //затычка на пока. Тут должен определяться типи тарелки перед принятием решения
                _pointsAfterDestroy = GameCore.Instance.GameSettings.BigSaucerPoints;
                break;
        }
    }

    private int GetAsteroidPointsInfo()
    {
        var size = GetComponent<AsteroidSettingsComponent>()?.Size;
        if (size == null)
        {
            print(GetType().ToString() + ": wrong tag on object " + gameObject.name);
            return 0;
        }

        switch (size)
        {
            case Asteroid.SizeType.Large:
                return GameCore.Instance.GameSettings.LargeAsteroidPoints;
            case Asteroid.SizeType.Medium:
                return GameCore.Instance.GameSettings.MediumAsteroidPoints;
            default:
                return GameCore.Instance.GameSettings.SmallAsteroidPoints;
        }
    }

    /// <summary>
    /// Checks if player caused destroying of an object and increased score for it
    /// </summary>
    private void CheckAndGivePoints(GameObject objCausedDestroying)
    {
        //Сделать через событие? Так этот класс не будет знать что происходит с этой информацией
        if (objCausedDestroying?.tag != "Player") return;
        //print(gameObject.name + " destroyed! +" + _pointsAfterDestroy);
        GameCore.Instance.AddPointsToScore(_pointsAfterDestroy);
    }

}
