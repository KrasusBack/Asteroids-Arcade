using UnityEngine;
using static AsteroidBehaviour;

[RequireComponent(typeof(AsteroidBehaviour))]
public sealed class AsteroidDestroyerComponent : Destroyable
{
    private AsteroidSize _asteroidSize;
    private bool _shatteringRightNow = false;

    private void Start()
    {
        _asteroidSize = GetComponent<AsteroidBehaviour>().Size;
    }

    protected override void BeforeDestroyOperation()
    {
        //Preventing more than 1 call from children colliders
        if (_shatteringRightNow) return;
        _shatteringRightNow = true;

        ShatterAsteroid();
    }

    private void ShatterAsteroid()
    {
        if (_asteroidSize == AsteroidSize.Small) return;
        SpawnFragments();
    }

    private void SpawnFragments()
    {
        var rb = GetComponent<Rigidbody2D>();

        for (var i = 0; i < 2; ++i)
        {
            var asteroidPrefab = GameCore.Instance.GameSettings.RandomAsteroidPrefab;
            var newAsteroid = Instantiate(asteroidPrefab, rb.position, transform.rotation);

            AsteroidSize newAsteroidSize = AsteroidBehaviour.GetPreviousSize(_asteroidSize);
            newAsteroid.GetComponent<AsteroidBehaviour>().SetAsteroidSettings(newAsteroidSize);
        }
    }

}
