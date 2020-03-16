using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    private static GameCore _instance = null;

    //public float gameSettings { get; private set; }

    

    public static GameCore GetInstance ()
    {
        
        return _instance;
    }

    private void SetInstance ()
    {
       //initialising 
    }

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
