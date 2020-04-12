using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class CenterUITextCaller : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        HideOverlay();
        GameCore.Instance.StageCleared += ChangeTextAndShowUI_StageCleared;
        GameCore.Instance.GameIsOver += ChangeTextAndShowUI_GameOver;
        GameCore.Instance.NewLevelInit += HideOverlay;
    }

    private void ChangeTextAndShowUI_StageCleared()
    {
        ChangeTextAndShowOverlay("Stage\nCleared");
    }
    private void ChangeTextAndShowUI_GameOver()
    {
        ChangeTextAndShowOverlay("Game\nOver");
    }

    private void ChangeTextAndShowOverlay(string newText)
    {
        textComponent.text = newText;
        ShowOverlay();
    }

    private void ShowOverlay()
    {
        GetComponent<TextMeshProUGUI>().enabled = true;
    }
    private void HideOverlay()
    {
        GetComponent<TextMeshProUGUI>().enabled = false;
    }
}
