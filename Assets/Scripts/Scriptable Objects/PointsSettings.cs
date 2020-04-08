using UnityEngine;

[CreateAssetMenu(fileName = "PointsSettings", menuName = "ScriptableObjects/PointsSettings", order = 5)]

public class PointsSettings : ScriptableObject
{
    [SerializeField]
    private int largeAsteroidPoints = 20;
    [SerializeField]
    private int mediumAsteroidPoints = 50;
    [SerializeField]
    private int smallAsteroidPoints = 100;
    [SerializeField]
    private int bigSaucerPoints = 200;
    [SerializeField]
    private int smalSaucerPoints = 1000;
    [SerializeField]
    private int costOfAddingBonusLife = 10000;

    #region Public Getters

    public int LargeAsteroidPoints
    {
        get => largeAsteroidPoints;
    }

    public int MediumAsteroidPoints
    {
        get => mediumAsteroidPoints;
    }

    public int SmallAsteroidPoints
    {
        get => smallAsteroidPoints;
    }

    public int BigSaucerPoints
    {
        get => bigSaucerPoints;
    }

    public int SmalSaucerPoints
    {
        get => smalSaucerPoints;
    }

    public int CostOfAddingBonusLife
    {
        get => costOfAddingBonusLife;
    }

    #endregion

}
