using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public sealed class GameCore : MonoBehaviour
{
    [SerializeField]
    private bool mainMenuMode = false;

    [SerializeField]
    private References references;
    [SerializeField]
    private GameObject playerShip;

    private const float normalTimeScale = 1.0f;

    private int _currentStage = 1;
    private int _livesCount = 3;
    private int _currentScore = 0;
    private int _destroyableObjectInTheScene = 0;

    private bool gameIsOver = false;
    private bool watchForDestroyables = true;
    private bool inMenu = false;

    private List<GameObject> destroyablesInTheScene = new List<GameObject>();
    private int DestroyablesInTheSceneCount
    {
        get
        {
            return _destroyableObjectInTheScene;
        }
        set
        {
            if (!watchForDestroyables) return;
            if (value < 0) throw new System.ArgumentOutOfRangeException("GameCore: DestroyableObjectInTheScene cant be < 0");
            _destroyableObjectInTheScene = value;
            if (value == 0)
            {
                print("...Calling StageCleared");
                InitiateNewLevel();
            }
        }
    }

    private HyperSpaceHandler HyperSpaceHandler { get; set; } = null;
    //for preventing from spawn in transitions (between level, time after death, etc)
    private bool CanActivatePlayerShip { get; set; } = true;
    private Quaternion playerShipInitialRotation;

    private AudioController audioController;

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
            if (value == 0) CanActivatePlayerShip = false;
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
    public References References => references;
    public GameObject PlayerShip => playerShip;
    public AudioController AudioController => audioController;
    #endregion

    #region Events, delegates
    public delegate void ScoreUpdateHandler();
    public event ScoreUpdateHandler ScoreUpdated;

    public delegate void StageNumberUpdateHandler();
    public event StageNumberUpdateHandler StageNumberUpdated;

    public delegate void LivesCountUpdateHandler();
    public event LivesCountUpdateHandler LivesCountUpdated;

    public delegate void GamePausedHandler();
    public event GamePausedHandler GamePaused;

    public delegate void GameResumedHandler();
    public event GameResumedHandler GameResumed;

    public delegate void GameOverHandler();
    public event GameOverHandler GameIsOver;

    public delegate void GameStartedHandler();
    public event GameStartedHandler NewLevelInit;

    public delegate void StageClearedHandler();
    public event StageClearedHandler StageCleared;

    public delegate void LevelStartedHandler();
    public event LevelStartedHandler LevelStarted; //no use for now

    public delegate void PlayerDiedHandler();
    public event PlayerDiedHandler PlayerDied;

    public delegate void PlayerRespawnedHandler();
    public event PlayerRespawnedHandler PlayerRespawned;
    #endregion

    private void Awake()
    {
        SetInstance();
    }
    private void Start()
    {
        if (!mainMenuMode)
        {
            StartNewGame();
            return;
        }
        //in main menu mode gamecore component exist just for references by other objects
        SwitchToMenuMode();
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
            print("-------GameCore set-------");
        }
    }
    private void Init()
    {
        if (PlayerShip.GetComponent<PlayerHyperSpaceComponent>() != null)
            HyperSpaceHandler = gameObject.AddComponent<HyperSpaceHandler>();

        LivesCount = References.PlayerShipSettings.StartingLifesAmount;

        playerShipInitialRotation = playerShip.transform.rotation;
        audioController = GetComponent<AudioController>();
        ResumeGame();
    }

    private void SwitchToMenuMode()
    {
        enabled = false;
        GameResumed?.Invoke();
    }

    #region Game Process control

    private void StartNewGame()
    {
        NewLevelInit?.Invoke();
    }
    private void ExecuteGameOver()
    {
        gameIsOver = true;
        GameIsOver?.Invoke();
    }
    private void InitiateNewLevel()
    {
        StartCoroutine(WaitAndStartNewLevel());
    }

    public void HandlePlayerDeath()
    {
        DisablePlayerShip();
        DeathAnimationCreator.CreatePlayerDeathEffect();
        if (LivesCount == 0)
        {
            //dramatic pause before calling game over ui overlay
            StartCoroutine(WaitBeforeCalling_GameOver());
            return;
        }
        PlayerShip.transform.position = (Vector2)Camera.main.transform.position;
        StartCoroutine(WaitBeforeCalling_Respawn());
    }
    private void RespawnPlayer()
    {
        RemoveLive();
        EnablePlayerShip();
        PlayerRespawned?.Invoke();
    }

    private IEnumerable CallStageTitleCardAndWait()
    {
        yield return new WaitForSeconds(References.LevelSettings.DelayBeforeNextLevel);
    }
    private IEnumerator WaitBeforeCalling_GameOver()
    {
        yield return new WaitForSeconds(References.LevelSettings.DelayBeforeRespawn);
        ExecuteGameOver();
    }
    private IEnumerator WaitBeforeCalling_Respawn()
    {
        CanActivatePlayerShip = false;
        yield return new WaitForSeconds(References.LevelSettings.DelayBeforeRespawn);
        PlayerDied?.Invoke(); //mainly used by overlay ui
        //check preventing end of the level (stage cleared) transition to the next level 
        CanActivatePlayerShip = true;
    }
    private IEnumerator WaitAndStartNewLevel()
    {
        yield return new WaitForSeconds(References.LevelSettings.DelayBeforeRespawn);
        StageCleared?.Invoke();
        DisablePlayerShip();
        CanActivatePlayerShip = false;

        //{ Stuff to celebrate stage clear }

        yield return new WaitForSeconds(References.LevelSettings.DelayBeforeNextLevel);
        if (LivesCount > 0)
        {
            DestroyAllDestroyableObjects();
            playerShip.transform.position = Vector3.zero;
            CurrentStage++;
            NewLevelInit?.Invoke();
            EnablePlayerShip();
            CanActivatePlayerShip = true;
        }
    }

    private void CheckAndHandleInput()
    {
        if (inMenu) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        #region Test functional
        #if UNITY_EDITOR
            //Reload scene
            if (Input.GetKeyDown(KeyCode.C)) ReloadScene();

            //Kill player
            if (Input.GetKeyDown(KeyCode.K)) HandlePlayerDeath();

            //Kill player
            if (Input.GetKeyDown(KeyCode.L))
            {
                print("Test: adding life");
                AddLife();
            }
        #endif
        #endregion

        //Respawn player
        if (!PlayerShip.activeSelf && Input.GetKeyDown(References.InputSettings.FireKey) && CanActivatePlayerShip)
        {
            RespawnPlayer();
        }
    }

    #endregion

    private void PauseGame()
    {
        print("GameCore: PauseGame");
        inMenu = true;
        Time.timeScale = 0;
        GamePaused?.Invoke();
    }
    public void ResumeGame()
    {
        print("GameCore: ResumeGame");
        StartCoroutine(WaitMenuesCallCooldown());
        Time.timeScale = normalTimeScale;
        GameResumed?.Invoke();
    }
    
    //Prevents immediate off/on menu calls 
    private IEnumerator WaitMenuesCallCooldown ()
    {
        yield return new WaitForEndOfFrame();
        inMenu = false;
    }

    private void BonusLifeCheckAndHandle(int scoreBeforeAddingNewPoints, int newScore)
    {
        var pointsNeededForBonusLife = References.PointsSettings.CostOfAddingBonusLife;

        //_gameIsOver check for preventing from recieving live after "game over" has been called
        if (!gameIsOver && (scoreBeforeAddingNewPoints / pointsNeededForBonusLife) < (newScore / pointsNeededForBonusLife))
            AddLife();
    }
    public void AddPointsToScore(int points)
    {
        BonusLifeCheckAndHandle(CurrentScore, CurrentScore += points);
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

    #region DestroyablesHandle
    public void AddNewDestroyableObjectToList(GameObject newDestroyable)
    {
        destroyablesInTheScene.Add(newDestroyable);
        DestroyablesInTheSceneCount++;
    }
    public void RemoveDestroyableObjectFromList(GameObject destroyable)
    {
        if (!watchForDestroyables) return;
        //preventing from double destroy call when DestroyAllObjects called
        destroyablesInTheScene.Remove(destroyable);
        DestroyablesInTheSceneCount--;
    }
    private void DestroyAllDestroyableObjects()
    {
        //disable destroyables calls because of manual launch of that
        watchForDestroyables = false;
        foreach (GameObject obj in destroyablesInTheScene)
            Destroy(obj);
        DestroyablesInTheSceneCount = 0;
        watchForDestroyables = true;
    }
    #endregion

    #region PlayeShipHandle
    public void DisablePlayerShip()
    {
        playerShip.SetActive(false);
    }
    public void EnablePlayerShip()
    {
        //because this method suppose to "respawn player" there is rotation update to init state
        playerShip.transform.rotation = playerShipInitialRotation;
        playerShip.SetActive(true);
    }
    public void TravelToHyperSpace()
    {
        HyperSpaceHandler.TravelToHyperSpace();
    }
    #endregion

    private void OnApplicationQuit()
    {
        Instance = null;
    }
    private void OnDestroy()
    {
        ClearEvents();
    }
    private void ClearEvents()
    {
        //preventing calls from/to destroyed objects OnDestroy calls 
        ScoreUpdated = null;
        StageNumberUpdated = null;
        LivesCountUpdated = null;
        GameIsOver = null;
        NewLevelInit = null;
        PlayerDied = null;
        StageCleared = null;
        PlayerRespawned = null;
        LevelStarted = null;
    }

    #region Stuff for Tests

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    #endregion

}
