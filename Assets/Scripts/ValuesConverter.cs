using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ValuesConverter
{
    /// <summary> Convert mixer volume value to standart value (from 0.0 to 1.0) </summary>
    public static float ConvertMixerVolumeToStandartValue(float mixerValue)
    {
        return Mathf.Pow(10, mixerValue / 20);
    }

    /// <summary> Convert standart volume value (from 0.0 to 1.0) to mixer value </summary>
    public static float ConvertStandartVolumeToMixerValue(float standartValue)
    {
        return Mathf.Log10(standartValue) * 20;
    }
}
