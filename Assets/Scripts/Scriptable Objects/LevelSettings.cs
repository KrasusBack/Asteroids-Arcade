using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObjects/LevelSettings", order = 6)]

public class LevelSettings : ScriptableObject
{
    [SerializeField, Min(0)]
    private int baseAsteroidAmount = 5;
    [SerializeField, Min(1)]
    private int asteroidsMaxAmount = 10;
    [SerializeField, Min(0)]
    private int additionalAsteroidsEachStage = 1;
    [SerializeField, Min(0), Tooltip("Min time from the beginning to start spawn saucers. With each second after that time probability of spawn will increase")]
    private int saucerSpawnTimer = 20;
    [SerializeField, Min(1)]
    private int littleSaucerFirstLevelAppearance = 3;
    [SerializeField, Min(1)]
    private int lastBigSaucerLevelApperance = 5;

    //Shorter cooldown between appearances?
    //Saucers shooting ability - spread
    //with each level - prob of BigSAucer appear. < prob. of Small saucer appear.

    #region Public Getters 
    public int BaseAsteroidAmount
    {
        get => baseAsteroidAmount;
    }
    public int AsteroidsMaxAmount
    {
        get => asteroidsMaxAmount;
    }
    public int AdditionalAsteroidsEachStage
    {
        get => additionalAsteroidsEachStage;
    }
    public int SaucerSpawnTimer
    {
        get => saucerSpawnTimer;
    }
    public int LittleSaucerFirstLevelAppearance
    {
        get => littleSaucerFirstLevelAppearance;
    }
    public int LastBigSaucerLevelApperance
    {
        get => lastBigSaucerLevelApperance;
    }
    
    #endregion
}
