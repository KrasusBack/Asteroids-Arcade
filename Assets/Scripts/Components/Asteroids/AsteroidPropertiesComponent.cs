﻿using UnityEngine;
using static Asteroid;
using System;

public sealed class AsteroidPropertiesComponent : MonoBehaviour
{
    [SerializeField]
    private SizeType asteroidSize = SizeType.Large;
    [Tooltip("Asteroid variation. -1 = random"), SerializeField, Min(-1)]
    private int variation = -1;

    private int Variation
    {
        get => variation;
        set
        {
            var asteroidPrefabsCount = GameCore.Instance.References.AsteroidsSettings.AsteroidPrefabsCount;
            if (variation > asteroidPrefabsCount)
            {
                variation = asteroidPrefabsCount;
                string errorMessage = $"{GetType().ToString()}: variation in {gameObject.name} out of range of AsteroidsSettings prefab counter ({asteroidPrefabsCount}). " +
                                      $"Variation number set to max ({asteroidPrefabsCount}";
                throw new IndexOutOfRangeException(errorMessage);
            }
        }
    }

    private void Start()
    {
        SetAsteroidAppearence();
        UpdateTransformScale();
    }

    public SizeType AsteroidSize
    {
        get => asteroidSize;
        private set => asteroidSize = value;
    }

    public void SetAsteroidSettings(SizeType newSize)
    {
        if (newSize == AsteroidSize) return;
        AsteroidSize = newSize;
    }

    private void UpdateTransformScale()
    {
        transform.localScale = FetchAsteroidSettings(AsteroidSize).sizeScale * Vector3.one;
    }

    /// <summary> Picks asteroid prefab with colliders and sprite, based on variation, and add it to object </summary>
    private void SetAsteroidAppearence()
    {
        var asterodAppearence = Instantiate(ChooseAppearance(), transform.position, Quaternion.identity);

        #region More Elegant approach
        /*
        //Attach colliders and sprite objects to actual asteroid object and destroy the provider
        foreach (Transform childTransform in asterodAppearence.transform)
        {
            childTransform.SetParent(transform);
        }

        Destroy(asterodAppearence);
        */
        #endregion

        //More robust approach: just attaching Appearance object
        asterodAppearence.transform.SetParent(transform);
        //Destroy dummy default sprite
        Destroy(GetComponent<SpriteRenderer>());
    }

    private GameObject ChooseAppearance()
    {
        if (Variation == -1) return GameCore.Instance.References.AsteroidsSettings.RandomAsteroid;
        return GameCore.Instance.References.AsteroidsSettings.GetCertainAsteroidPrefab(Variation);
    }
}
