using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public sealed class GameCore : MonoBehaviour
{
    [SerializeField]
    private AsteroidsSettings asteroidsSettings;
    [SerializeField]
    private PlayerShipSettings playerShipSettings;
    [SerializeField]
    private SaucersSettings saucersSettings;
    [SerializeField]
    private PointsSettings pointsSettings;
    [SerializeField]
    private InputSettings inputSettings;
    [SerializeField]
    private LevelSettings levelSettings;

    [SerializeField]
    private GameObject playerShip;

    private int _currentStage = 1;
    private int _livesCount = 3;
    private int _currentScore = 0;
    private int _destroyableObjectInTheScene = 0;

    private int DestroyableObjectsInTheScene
    {
        get
        {
            return _destroyableObjectInTheScene;
        }

        set
        {
            if (value < 0) throw new System.ArgumentOutOfRangeException("DestroyableObjectInTheScene cant be < 0");
            _destroyableObjectInTheScene = value;
            if (value == 0)
            {
                print("...Calling StageCleared");
                StageCleared?.Invoke();
            }
                
        }
    }
    private HyperSpaceHandler HyperSpaceHandler { get; set; } = null;
    private bool PlayerCanBeRespawned { get; set; } = true;

    public static GameCore Instance { get; private set; } = null;

    public int CurrentStage
    {
        get
        {
            return _currentStage;
        }
        private set
        {
            _currentStage = value;
            StageNumberUpdated?.Invoke();
        }
    }
    public int LivesCount
    {
        get
        {
            return _livesCount;
        }
        private set
        {
            _livesCount = value;
            LivesCountUpdated?.Invoke();
            if (value == 0) PlayerCanBeRespawned = false;
        }
    }
    public int CurrentScore
    {
        get
        {
            return _currentScore;
        }
        private set
        {
            _currentScore = value;
            ScoreUpdated?.Invoke();
        }
    }

    #region Public Getters
    public AsteroidsSettings AsteroidsSettings
    {
        get => asteroidsSettings;
    }
    public PlayerShipSettings PlayerShipSettings
    {
        get => playerShipSettings;
    }
    public SaucersSettings SaucersSettings
    {
        get => saucersSettings;
    }
    public PointsSettings PointsSettings
    {
        get => pointsSettings;
    }
    public InputSettings InputSettings
    {
        get => inputSettings;
    }
    public LevelSettings LevelSettings
    {
        get => levelSettings;
    }

    public GameObject PlayerShip
    {
        get => playerShip;
    }
    #endregion

    public delegate void ScoreUpdateHandler();
    public event ScoreUpdateHandler ScoreUpdated;

    public delegate void StageNumberUpdateHandler();
    public event StageNumberUpdateHandler StageNumberUpdated;

    public delegate void LivesCountUpdateHandler();
    public event LivesCountUpdateHandler LivesCountUpdated;

    public delegate void GameOverHandler();
    public event GameOverHandler GameIsOver;

    public delegate void GameStartedHandler();
    public event GameStartedHandler NewLevelStarted;

    public delegate void PlayerDiedHandler();
    public event PlayerDiedHandler PlayerDied;

    public delegate void StageClearedHandler();
    public event StageClearedHandler StageCleared;

    private void Awake()
    {
        SetInstance();
    }
    private void Start()
    {
        StartNextLevel();
    }
    private void Update()
    {
        CheckAndHandleInput();
    }

    private void SetInstance()
    {
        if (Instance == null)
        {
            Init();
            Instance = this;
            print("-------Game Started!-------");
        }
    }
    private void Init()
    {
        if (PlayerShip.GetComponent<PlayerHyperSpaceComponent>() != null)
            HyperSpaceHandler = gameObject.AddComponent<HyperSpaceHandler>();

        LivesCount = PlayerShipSettings.StartingLifesAmount;
    }

    #region Game Process control

    private void StartNextLevel()
    {
        NewLevelStarted?.Invoke();
    }
    private void ExecuteGameOver()
    {
        GameIsOver?.Invoke();
    }

    public void HandlePlayerDeath()
    {
        PlayerShip.SetActive(false);
        if (LivesCount == 0)
        {
            StartCoroutine(WaitBeforeCalling_GameOver()); // dramatic pause before calling game over overlay
            return;
        }
        PlayerShip.transform.position = Vector3.zero;
        StartCoroutine(WaitBeforeCalling_Respawn());
    }
    private IEnumerator WaitBeforeCalling_GameOver()
    {
        yield return new WaitForSeconds(PlayerShipSettings.DelayBeforeRespawn);
        ExecuteGameOver();
    }
    private IEnumerator WaitBeforeCalling_Respawn()
    {
        PlayerCanBeRespawned = false;
        yield return new WaitForSeconds(PlayerShipSettings.DelayBeforeRespawn);
        PlayerDied?.Invoke(); //mainly used by overlay ui
        PlayerCanBeRespawned = true;
    } 
    
    private void RespawnPlayer()
    {
        RemoveLive();
        PlayerShip.SetActive(true);
    }

    private void CheckAndHandleInput()
    {
        //Reload scene
        if (Input.GetKeyDown(KeyCode.C)) ReloadScene();

        //Kill player
        if (Input.GetKeyDown(KeyCode.K)) HandlePlayerDeath();

        //Respawn player
        if (!PlayerShip.activeSelf && Input.GetKeyDown(InputSettings.FireKey) && PlayerCanBeRespawned)
        {
            RespawnPlayer();
        }
    }

    #endregion
    
    private void BonusLifeCheckAndHandle(int scoreBeforeAddingNewPoints, int newScore)
    {
        var pointsNeededForBonusLife = PointsSettings.CostOfAddingBonusLife;

        if ((scoreBeforeAddingNewPoints / pointsNeededForBonusLife) < (newScore / pointsNeededForBonusLife))
            AddLife();
    }
    public void AddPointsToScore(int points)
    {
        BonusLifeCheckAndHandle(CurrentScore, CurrentScore += points);
    }

    public void IncreaseDestroyableObjectsCounter()
    {
        DestroyableObjectsInTheScene++;
    }
    public void DecreaseDestroyableObjectsCounter()
    {
        DestroyableObjectsInTheScene--;
    }
    
    public void TravelToHyperSpace()
    {
        HyperSpaceHandler.TravelToHyperSpace();
    }

    private void AddLife()
    {
        print("! Bonus life added !"); //add bonus life event
        LivesCount++;
    }
    private void RemoveLive()
    {
        LivesCount--;
    }

    private void OnDestroy()
    {
        ClearEvents();
    }
    private void ClearEvents()
    {
        ScoreUpdated = null;
        StageNumberUpdated = null;
        LivesCountUpdated = null;
        GameIsOver = null;
        NewLevelStarted = null;
        PlayerDied = null;
        StageCleared = null;
    }

    #region Stuff for Tests

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    #endregion

}
