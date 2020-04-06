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

    private HyperSpaceHandler hyperSpaceHandler = null;

    public static GameCore Instance { get; private set; } = null;

    public delegate void ScoreUpdateHandler();
    public event ScoreUpdateHandler ScoreUpdated;

    public delegate void StageNumberUpdateHandler();
    public event StageNumberUpdateHandler StageNumberUpdated;

    public delegate void LivesCountUpdateHandler();
    public event LivesCountUpdateHandler LivesCountUpdated;

    public GameSettings GameSettings
    {
        get => gameSettings;
    }

    public GameObject PlayerShip
    {
        get => playerShip;
    }

    public void TravelToHyperSpace()
    {
        hyperSpaceHandler.TravelToHyperSpace();
    }

    private void Awake()
    {
        SetInstance();
    }

    private void Update()
    {
        //Reload scene
        if (Input.GetKeyDown(KeyCode.C))
        {
            ReloadScene();
        }

        //Kill player
        if (Input.GetKeyDown(KeyCode.K))
        {
            HandlePlayerDeath();
        }

        if (!PlayerShip.activeSelf && Input.GetKeyDown(GameSettings.ShootKey) && LivesCount > 0)
        {
            RespawnPlayer();
        }
    }

    private void SetInstance()
    {
        if (Instance == null)
        {
            if (PlayerShip.GetComponent<PlayerHyperSpaceComponent>() != null)
                hyperSpaceHandler = gameObject.AddComponent<HyperSpaceHandler>();

            LivesCount = GameSettings.StartingLifesAmount;

            Instance = this;
        }
    }

    #region Game Process control

    public void HandlePlayerDeath()
    {
        if (LivesCount == 0)
        {
            ExecuteGameOver();
            return;
        }

        PlayerShip.SetActive(false);
        PlayerShip.transform.position = Vector3.zero;
        print("Press Fire Button to respawn. " + LivesCount + " lives left");
    }

    private void ExecuteGameOver()
    {
        PlayerShip.SetActive(false);
        print("Game over buddy");
    }

    private void RespawnPlayer()
    {
        DecreaseLivesCounter();
        PlayerShip.SetActive(true);
    }

    #endregion

    public void AddPointsToScore(int points)
    {
        BonusLifeCheckAndHandle(CurrentScore, CurrentScore += points);

        print("Current Score: " + CurrentScore);
    }

    private void BonusLifeCheckAndHandle(int scoreBeforeAddingNewPoints, int newScore)
    {
        var pointsNeededForBonusLife = GameSettings.PointsForAddingLife;

        if ((scoreBeforeAddingNewPoints / pointsNeededForBonusLife) < (newScore / pointsNeededForBonusLife))
            AddLife();
    }

    private void AddLife()
    {
        print("! Bonus life added !");
        LivesCount++;
    }

    private void DecreaseLivesCounter()
    {
        LivesCount--;
    }

    //test stuff: reload scene
    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
