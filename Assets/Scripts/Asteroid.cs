﻿public static class Asteroid
{
    public enum SizeType { Large, Medium, Small };

    [System.Serializable]
    public struct AsteroidProperties
    {
        public float speed;
        public float sizeScale;
    }

    public static AsteroidProperties FetchAsteroidSettings(SizeType asteroidSize)
    {
        switch (asteroidSize)
        {
            case SizeType.Large:
                return GameCore.Instance.AsteroidsSettings.LargeAsteroid;
            case SizeType.Medium:
                return GameCore.Instance.AsteroidsSettings.MediumAsteroid;
        }
        return GameCore.Instance.AsteroidsSettings.SmallAsteroid;
    }

    //Returns Small Size if there is no previous
    public static SizeType GetPreviousSize(SizeType size)
    {
        if (size == SizeType.Large) return SizeType.Medium;
        return SizeType.Small;
    }
}
