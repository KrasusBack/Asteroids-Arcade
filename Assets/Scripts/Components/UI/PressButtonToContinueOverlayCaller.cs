using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressButtonToContinueOverlayCaller : MonoBehaviour
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
        GetComponent<TextMeshProUGUI>().enabled = true;
    }

    private void HideOverlay()
    {
        GetComponent<TextMeshProUGUI>().enabled = false;
    }
}
