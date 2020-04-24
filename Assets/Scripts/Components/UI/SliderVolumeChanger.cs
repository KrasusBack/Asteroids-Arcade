using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SliderVolumeChanger : MonoBehaviour
{
    private Slider slider;
    private AudioSource audioSource;
    private string masterVolumeName = "MasterVolume";

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //set up start value
        float audioMixerValue;
        if (!GameCore.Instance.AudioController.AudioMixer.GetFloat(masterVolumeName, out audioMixerValue))
            print($"Can't get starting {masterVolumeName} value");
        slider.value = Mathf.Pow(10, audioMixerValue / 20);

    }

    public void ChangeMasterVolume()
    {
        if (GameCore.Instance.AudioController.AudioMixer.SetFloat(masterVolumeName, Mathf.Log10(slider.value) * 20))
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
            return;
        }
        print($"Can't change {masterVolumeName} setting");
    }

}
