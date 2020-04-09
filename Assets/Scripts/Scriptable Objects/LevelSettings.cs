using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObjects/LevelSettings", order = 6)]

public class LevelSettings : ScriptableObject
{
    [SerializeField, Min(0)]
    private int baseAsteroidAmount = 6;
    [SerializeField, Min(0)]
    private int additionalAsteroidsEachStage = 2;
    [SerializeField, Min(0)]
    private int baseSaucersAmount = 1;
    [SerializeField, Min(1)]
    private int littleSaucerFirstLevelAppearance = 3;

    //Additional saucers with each level? Shorter cooldown between appearances?
    //Saucers shooting ability - spread
    //saucers avoiding ability 
    //game speed?

    #region Public Getters 
    public int BaseAsteroidAmount
    {
        get => baseAsteroidAmount;
    }
    public int AdditionalAsteroidsEachStage
    {
        get => additionalAsteroidsEachStage;
    }
    public int BaseSaucersAmount
    {
        get => baseSaucersAmount;
    }
    public int LittleSaucerFirstLevelAppearance
    {
        get => littleSaucerFirstLevelAppearance;
    }
    #endregion
}
