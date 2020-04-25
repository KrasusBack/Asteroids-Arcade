using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeTextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;

    public void UpdateVolumeText(UnityEngine.Audio.AudioMixer audioMixer)
    {
        float newValue;
        if (audioMixer.GetFloat(AudioController.masterVolumeName, out newValue))
        {
            textMeshPro.text = $"Volume: {(int)(AudioController.ConvertMixerVolumeToStandartValue(newValue) * 100)}%";
        }
        else print($"VolumeTextUpdater: can't get {AudioController.masterVolumeName} value to update text");
    }
}
