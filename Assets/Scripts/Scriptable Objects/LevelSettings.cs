using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObjects/LevelSettings", order = 6)]

public class LevelSettings : ScriptableObject
{
    [Header("GameSettings")]
    [SerializeField, Min(0.1f)]
    private float delayBeforeNextLevel = 3;
    [SerializeField, Min(0.1f)]
    private float delayBeforeRespawn = 1;
    [Header("Asteroids")]
    [SerializeField, Min(0)]
    private int baseAsteroidAmount = 5;
    [SerializeField, Min(1)]
    private int asteroidsMaxAmount = 10;
    [SerializeField, Min(0)]
    private int additionalAsteroidsEachStage = 1;
    [Header("Saucers")]
    [SerializeField, Min(0)]
    private float saucerSpawnTimer = 20;
    [SerializeField, Min(0)]
    private float delayUntilSpawnNewSaucer = 15;
    [SerializeField, Min(1)]
    private int littleSaucerFirstLevelAppearance = 3;
    [SerializeField, Min(1)]
    private int lastBigSaucerLevelApperance = 5;
    [SerializeField, Min(1)]
    private int maxSaucersForLevel = 3;
    [SerializeField, Min(1)]
    private int maxSaucersOnScreen = 1;
    [SerializeField, Min(1)]
    private int increaseMaxSaucerOnScreenEachLevels = 3;

    //Shorter cooldown between appearances?
    //Saucers shooting ability - spread
    //with each level - prob of BigSAucer appear. < prob. of Small saucer appear.

    #region Public Getters 

    public float DelayBeforeNextLevel
    {
        get => delayBeforeNextLevel;
    }
    public float DelayBeforeRespawn
    {
        get => delayBeforeRespawn;
    }
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
    public float SaucerSpawnTimer
    {
        get => saucerSpawnTimer;
    }
    public float DelayUntilSpawnNewSaucer
    {
        get => delayUntilSpawnNewSaucer;
    }
    public int LittleSaucerFirstLevelAppearance
    {
        get => littleSaucerFirstLevelAppearance;
    }
    public int LastBigSaucerLevelApperance
    {
        get => lastBigSaucerLevelApperance;
    }
    public int MaxSaucersForLevel
    {
        get => maxSaucersForLevel;
    }
    public int MaxSaucersOnScreen
    {
        get => maxSaucersOnScreen;
    }
    public int IncreaseMaxSaucerOnScreenEachLevels
    {
        get => increaseMaxSaucerOnScreenEachLevels;
    }
    
    #endregion
}
