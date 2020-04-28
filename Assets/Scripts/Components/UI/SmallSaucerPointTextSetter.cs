using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SmallSaucerPointTextSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "- " + GameCore.Instance.References.PointsSettings.SmallSaucerPoints.ToString();
    }
}
