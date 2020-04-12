using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class GameOverOverlayCaller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameCore.Instance.GameIsOver += ShowOverlay;
        GameCore.Instance.NewLevelStarted += HideOverlay;
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
