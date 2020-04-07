using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameCore : MonoBehaviour
{
    [SerializeField]
    private GameSettings gameSettings;
    [SerializeField]
    private GameObject playerShip;

    private int _currentStage = 1;
    private int _livesCount = 3;
    private int _currentScore = 0;

    private HyperSpaceHandler HyperSpaceHandler { get; set; } = null;

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

    public GameSettings GameSettings
    {
        get => gameSettings;
    }
    public GameObject PlayerShip
    {
        get => playerShip;
    }


    public delegate void ScoreUpdateHandler();
    public event ScoreUpdateHandler ScoreUpdated;

    public delegate void StageNumberUpdateHandler();
    public event StageNumberUpdateHandler StageNumberUpdated;

    public delegate void LivesCountUpdateHandler();
    public event LivesCountUpdateHandler LivesCountUpdated;

    public delegate void GameOverHandler();
    public event GameOverHandler GameIsOver;

    public delegate void PlayerDiedHandler();
    public event PlayerDiedHandler PlayerDied;


    private void Awake()
    {
        SetInstance();
    }

    private void Update()
    {
        CheckAndHandleInput();
    }

    private void CheckAndHandleInput()
    {
        //Reload scene
        if (Input.GetKeyDown(KeyCode.C)) ReloadScene();

        //Kill player
        if (Input.GetKeyDown(KeyCode.K)) HandlePlayerDeath();

        //Respawn player
        if (!PlayerShip.activeSelf && Input.GetKeyDown(GameSettings.FireKey) && LivesCount > 0)
        {
            RespawnPlayer();
        }
    }

    private void SetInstance()
    {
        if (Instance == null)
        {
            Init();
            Instance = this;
        }
    }

    private void Init()
    {
        if (PlayerShip.GetComponent<PlayerHyperSpaceComponent>() != null)
            HyperSpaceHandler = gameObject.AddComponent<HyperSpaceHandler>();

        LivesCount = GameSettings.StartingLifesAmount;
    }

    #region Game Process control

    public void HandlePlayerDeath()
    {
        if (LivesCount == 0) { ExecuteGameOver(); return; }

        PlayerShip.SetActive(false);
        PlayerShip.transform.position = Vector3.zero;
        PlayerDied?.Invoke();
    }

    private void ExecuteGameOver()
    {
        PlayerShip.SetActive(false);
        GameIsOver?.Invoke();
    }

    private void RespawnPlayer()
    {
        DecreaseLivesCounter();
        PlayerShip.SetActive(true);
    }

    #endregion

    public void TravelToHyperSpace()
    {
        HyperSpaceHandler.TravelToHyperSpace();
    }

    public void AddPointsToScore(int points)
    {
        BonusLifeCheckAndHandle(CurrentScore, CurrentScore += points);
    }

    private void BonusLifeCheckAndHandle(int scoreBeforeAddingNewPoints, int newScore)
    {
        var pointsNeededForBonusLife = GameSettings.PointsForAddingLife;

        if ((scoreBeforeAddingNewPoints / pointsNeededForBonusLife) < (newScore / pointsNeededForBonusLife))
            AddLife();
    }

    private void AddLife()
    {
        print("! Bonus life added !"); //add bonus life event
        LivesCount++;
    }

    private void DecreaseLivesCounter()
    {
        LivesCount--;
    }

    #region Stuff for Tests

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    #endregion

}
