using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidsPointsTextSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var text = $"Big - {GameCore.Instance.References.PointsSettings.LargeAsteroidPoints}{System.Environment.NewLine}" +
                   $"Medium - {GameCore.Instance.References.PointsSettings.MediumAsteroidPoints}{System.Environment.NewLine}" +
                   $"Small - {GameCore.Instance.References.PointsSettings.SmallAsteroidPoints}";

        GetComponent<TextMeshProUGUI>().text = text;
    }
}
