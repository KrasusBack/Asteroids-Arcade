using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameCore : MonoBehaviour
{
    [SerializeField]
    private GameSettings gameSettings;
    [SerializeField]
    private GameObject playerShip;

    private int _currentWave = 1;
    private int _livesCount = 3;
    private int _currentScore = 0;

    private HyperSpaceHandler hyperSpaceHandler = null;

    public static GameCore Instance { get; private set; } = null;


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
        if (Input.GetKeyDown(KeyCode.C))
        {
            ReloadScene();
        }

        if (!PlayerShip.activeSelf && Input.GetKeyDown(GameSettings.ShootKey) && _livesCount > 0)
        {
            RespawnPlayer();
        }
    }

    private void FixedUpdate()
    {
        if (PlayerShip == null) print("Player is gone!");
    }


    private void SetInstance()
    {
        if (Instance == null)
        {
            if (PlayerShip.GetComponent<PlayerHyperSpaceComponent>() != null)
                hyperSpaceHandler = gameObject.AddComponent<HyperSpaceHandler>();

            Instance = this;
        }
    }

    public void HandlePlayerDeath()
    {
        if (!Instance.DecreaseLivesCounter())
        {
            Instance.ExecuteGameOver();
            return;
        }

        PlayerShip.SetActive(false);
        PlayerShip.transform.position = Vector3.zero;
        print("Press Fire Button to respawn. " + _livesCount + " lives left");
    }

    private void ExecuteGameOver()
    {
        PlayerShip.SetActive(false);
        print("Game over buddy");
    }

    private void RespawnPlayer()
    {
        PlayerShip.SetActive(true);
    }

    /// <summary>
    /// Decreases lives counter. Return true if there are lives left
    /// </summary>
    private bool DecreaseLivesCounter()
    {
        _livesCount--;
        if (_livesCount == 0) return false;
        return true;
    }

    //test stuff: reload scene
    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
