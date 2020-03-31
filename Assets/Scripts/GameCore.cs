using UnityEngine;

public class GameCore : MonoBehaviour
{
    [SerializeField]
    private GameSettings gameSettings;
    [SerializeField]
    private GameObject playerShip;

    private int _currentWave = 1;
    private int _livesCount = 3;
    private int _currentScore = 0;

    public static GameCore Instance { get; private set; } = null;

    public GameSettings GameSettings
    {
        get => gameSettings;
    }

    private void SetInstance()
    {
        if (Instance == null) Instance = this;
    }

    public GameObject PlayerShip
    {
        get => playerShip;
    }

    private void Awake()
    {
        SetInstance();
    }
}
