using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MenuBase
{
    // Start is called before the first frame update
    void Start()
    {
        print("PauseMenu: HideMenues>");
        HideMenues();
        GameCore.Instance.GamePaused += ShowMenu;
    }

    public void ResumeGame()
    {
        print("PauseMenu: ResumeGame");
        GameCore.Instance.ResumeGame();
        Menu.SetActive(false);
    }

    public void ToMainMenu()
    {
        print("PauseMenu: ToMainMenu");
        SceneManager.LoadScene("MainMenu");
    }
}
