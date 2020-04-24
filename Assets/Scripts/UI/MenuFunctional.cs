using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctional : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SettingsMenu;

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CallSettingsMenu()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void CallMainMenu()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

}
