using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    [SerializeField]
    private GameSettings gameSettings;

    private static GameCore _instance = null;

    //public float gameSettings { get; private set; }
    

    public static GameCore GetInstance ()
    {
        return _instance;
    }

    public GameSettings GameSettings()
    {
        return gameSettings;
    }

    private void SetInstance ()
    {
        if (_instance == null) _instance = this;
    }

   
    // Start is called before the first frame update
    void Awake()
    {
        SetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
