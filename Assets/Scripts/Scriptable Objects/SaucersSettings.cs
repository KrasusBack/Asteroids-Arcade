using UnityEngine;

[CreateAssetMenu(fileName = "SaucersSettings", menuName = "ScriptableObjects/SaucersSettings", order = 3)]

public class SaucersSettings : ScriptableObject
{
    [Header("Saucer Stats")]
    [SerializeField]
    private Saucer bigSaucer;
    [SerializeField]
    private Saucer smallSaucer;

    #region PublicGetters

    public Saucer BigSaucer
    {
        get => bigSaucer;
    }

    public Saucer SmallSaucer
    {
        get => smallSaucer;
    }

    #endregion
}

