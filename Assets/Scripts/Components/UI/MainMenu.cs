using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MenuBase
{
    private void Start()
    {
        print("MainMenu: ShowMenu>");
        ShowMenu();
    }

    public void StartGame()
    {
        print("MainMenu: StartGame");
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        print("MainMenu: QuitGame");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
                        Application.Quit();
        #endif
    }

}
