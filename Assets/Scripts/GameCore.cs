using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    [SerializeField]
    private GameSettings gameSettings;
    [SerializeField]
    private GameObject playerShip;

    private static GameCore _instance = null;

    private int _currentWave = 1;
    private int _livesCount = 3;
    private int _currentScore = 0;


    public static GameCore GetInstance()
    {
        return _instance;
    }

    public GameSettings GameSettings()
    {
        return gameSettings;
    }

    private void SetInstance()
    {
        if (_instance == null) _instance = this;
    }

    public GameObject PlayerShip()
    {
        return playerShip;
    }


    // Start is called before the first frame update
    void Awake()
    {
        SetInstance();
    }

}
