using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class PressButtonToContinueOverlayCaller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HideOverlay();
        GameCore.Instance.PlayerDied += ShowOverlay;
        GameCore.Instance.LivesCountUpdated += HideOverlay;
    }

    private void ShowOverlay()
    {
        var component = GetComponent<TextMeshProUGUI>();
        component.text = "press [" + GameCore.Instance.GameSettings.FireKey.ToString() + "] button to resurrect";
        component.enabled = true;
    }

    private void HideOverlay()
    {
        GetComponent<TextMeshProUGUI>().enabled = false;
    }
}
