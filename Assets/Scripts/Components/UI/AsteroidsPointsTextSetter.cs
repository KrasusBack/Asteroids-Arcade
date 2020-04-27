using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidsPointsTextSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var text = $"Big - {GameCore.Instance.PointsSettings.LargeAsteroidPoints}{System.Environment.NewLine}" +
                   $"Medium - {GameCore.Instance.PointsSettings.MediumAsteroidPoints}{System.Environment.NewLine}" +
                   $"Small - {GameCore.Instance.PointsSettings.SmallAsteroidPoints}";

        GetComponent<TextMeshProUGUI>().text = text;
    }
}
