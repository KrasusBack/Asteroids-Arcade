using UnityEngine;
using static Asteroid;

public class AsteroidSettingsComponent : MonoBehaviour
{
    public SizeType Size { get; private set; } = SizeType.Large;

    public void SetAsteroidSettings(SizeType size)
    {
        Size = size;
        transform.localScale = FetchAsteroidSettings(size).sizeScale * Vector3.one;
    }
}
