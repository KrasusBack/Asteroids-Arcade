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
        GameCore.Instance.PlayerRespawned += HideOverlay;
        //preventing "death" + "end of the level" situations
        GameCore.Instance.StageCleared += HideOverlay;
    }

    private void ShowOverlay()
    {
        var component = GetComponent<TextMeshProUGUI>();
        component.text = "press [" + GameCore.Instance.References.InputSettings.FireKey.ToString() + "] button to respawn";
        component.enabled = true;
    }

    private void HideOverlay()
    {
        GetComponent<TextMeshProUGUI>().enabled = false;
    }
}
