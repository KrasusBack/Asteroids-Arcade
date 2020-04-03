﻿using UnityEngine;
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

    //test stuff: reload scene
    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
   
}
