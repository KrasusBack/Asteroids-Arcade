using UnityEngine;

[CreateAssetMenu(fileName = "SaucersSettings", menuName = "ScriptableObjects/SaucersSettings", order = 3)]

public class SaucersSettings : ScriptableObject
{
    [Header("Saucer Stats")]
    [SerializeField]
    private SaucerStats bigSaucerStats;
    [SerializeField]
    private SaucerStats smallSaucerStats;

    #region PublicGetters

    public SaucerStats BigSaucerStats
    {
        get => bigSaucerStats;
    }

    public SaucerStats SmallSaucerStats
    {
        get => smallSaucerStats;
    }

    #endregion
}

