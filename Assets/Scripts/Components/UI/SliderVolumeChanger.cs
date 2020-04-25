﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SliderVolumeChanger : MonoBehaviour
{
    private Slider slider;
    private AudioSource audioSource;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //set up start value
        float audioMixerValue;
        if (!GameCore.Instance.AudioController.AudioMixer.GetFloat(AudioController.masterVolumeName, out audioMixerValue))
            print($"Can't get starting {AudioController.masterVolumeName} value");
        slider.value = AudioController.ConvertMixerVolumeToStandartValue(audioMixerValue);

    }

    public void ChangeMasterVolume()
    {
        if (GameCore.Instance.AudioController.AudioMixer.SetFloat(AudioController.masterVolumeName,
                                                                  AudioController.ConvertStandartVolumeToMixerValue(slider.value)))
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
            return;
        }
        print($"Can't change {AudioController.masterVolumeName} setting");
    }

}
