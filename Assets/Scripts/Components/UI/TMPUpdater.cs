using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class TMPUpdater : MonoBehaviour
{
    protected TextMeshProUGUI TextComponent { get; private set; }

    void Start()
    {
        TextComponent = GetComponent<TextMeshProUGUI>();
        AdditionalOperationsInStart();
    }

    /// <summary>
    /// Additional operation that will be executed in Start
    /// </summary>
    protected virtual void AdditionalOperationsInStart() {}
}
