using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverOverlayCaller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HideOverlay();
        GameCore.Instance.GameIsOver += ShowOverlay;
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
