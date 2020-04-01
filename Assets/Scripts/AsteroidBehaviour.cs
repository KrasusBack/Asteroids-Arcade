using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public enum AsteroidSize { Large, Medium, Small };

    public AsteroidSize Size { get; private set; } = AsteroidSize.Large;

    public void SetAsteroidSettings(AsteroidSize size)
    {
        Size = size;
        transform.localScale = FetchAsteroidSettings(size).sizeScale * Vector3.one;
    }

    public static GameSettings.AsteroidProperties FetchAsteroidSettings(AsteroidSize asteroidSize)
    {
        switch (asteroidSize)
        {
            case AsteroidSize.Large:
                return GameCore.Instance.GameSettings.LargeAsteroid;
            case AsteroidSize.Medium:
                return GameCore.Instance.GameSettings.MediumAsteroid;
        }
        return GameCore.Instance.GameSettings.SmallAsteroid;
    }

    //Returns Small Size if there is no previous
    public static AsteroidSize GetPreviousSize(AsteroidSize size)
    {
        if (size == AsteroidSize.Large) return AsteroidSize.Medium;
        return AsteroidSize.Small;
    }
}
