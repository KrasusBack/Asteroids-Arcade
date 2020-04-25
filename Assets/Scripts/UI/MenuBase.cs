using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenuBase : MonoBehaviour
{
    [SerializeField] public GameObject Menu;
    [SerializeField] public GameObject SettingsMenu;

    public void ShowSettingsMenu()
    {
        Menu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void ShowMenu()
    {
        Menu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    public void HideMenues()
    {
        Menu.SetActive(false);
        SettingsMenu.SetActive(false);
    }
}
