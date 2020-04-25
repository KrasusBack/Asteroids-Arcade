using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPreviousMenu : MonoBehaviour
{
    [SerializeField] private MenuBase menuHandler;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuHandler.ShowMenu();    
        }
    }
}
