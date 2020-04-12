using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class StageClearedOverlayCaller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HideOverlay();
        GameCore.Instance.StageCleared += ShowOverlay;
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
