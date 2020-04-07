using UnityEngine;
using static Asteroid;

public sealed class AsteroidSettingsComponent : MonoBehaviour
{
    [SerializeField]
    private SizeType asteroidSize = SizeType.Large;

    private void Start()
    {
        SetAsteroidSettings();
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
        SetAsteroidSettings();
    }

    private void SetAsteroidSettings()
    {
        transform.localScale = FetchAsteroidSettings(AsteroidSize).sizeScale * Vector3.one;
    }
}
