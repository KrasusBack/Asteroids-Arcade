using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class PauseMenu : MenuBase
{
    // Start is called before the first frame update
    void Start()
    {
        HideMenues();
        GameCore.Instance.GamePaused += ShowMenu;
    }

    public void ResumeGame()
    {
        GameCore.Instance.ResumeGame();
        HideMenues();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
