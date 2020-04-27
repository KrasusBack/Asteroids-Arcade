using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BigSaucerPointsTextSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "- " + GameCore.Instance.PointsSettings.BigSaucerPoints.ToString();
    }
}
