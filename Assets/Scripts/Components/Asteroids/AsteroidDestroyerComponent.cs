﻿using UnityEngine;
using static Asteroid;

[RequireComponent(typeof(AsteroidPropertiesComponent))]
public sealed class AsteroidDestroyerComponent : Destroyable
{
    private SizeType AsteroidSize { get; set; }

    protected override void DoInStart()
    {
        AsteroidSize = GetComponent<AsteroidPropertiesComponent>().AsteroidSize;
    }

    protected override void BeforeDestroyOperation()
    {
        ShatterAsteroid();
    }

    private void ShatterAsteroid()
    {
        if (AsteroidSize == SizeType.Small) return;
        SpawnFragments();
    }

    private void SpawnFragments()
    {
        var rb = GetComponent<Rigidbody2D>();

        for (var i = 0; i < 2; ++i)
        {
            var asteroidPrefab = GameCore.Instance.References.AsteroidsSettings.AsteroidBaseObject;
            var newAsteroid = Instantiate(asteroidPrefab, rb.position, transform.rotation);

            SizeType newAsteroidSize = GetPreviousSize(AsteroidSize);
            newAsteroid.GetComponent<AsteroidPropertiesComponent>().SetAsteroidSettings(newAsteroidSize);
        }
    }

}
