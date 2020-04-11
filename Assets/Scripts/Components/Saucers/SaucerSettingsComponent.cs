using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerSettingsComponent : MonoBehaviour
{
    public enum SaucerType { Big, Small};

    [SerializeField]
    private SaucerType type;

    public SaucerType Type
    {
        get => type;
    }

    /// <summary>
    /// Get stats from GameCore SaucerSettings. It will be based on Type of SaucerSettingsComponent. 
    /// </summary>
    public Saucer GetSettings()
    {
        switch (Type)
        {
            case SaucerType.Big:
                return GameCore.Instance.SaucersSettings.BigSaucer;
            case SaucerType.Small:
                return GameCore.Instance.SaucersSettings.SmallSaucer;
            default:
                throw new System.Exception("There is no SaucerSettings for " + Type);
        }
    }

}
