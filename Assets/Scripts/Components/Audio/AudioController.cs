using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public sealed class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    
    public AudioMixer AudioMixer { get => audioMixer; }

    public static string masterVolumeName = "MasterVolume";

    private void Start()
    {
        GameCore.Instance.GamePaused += PauseAudio;
        GameCore.Instance.GameResumed += ResumeAudio;
    }

    private void PauseAudio()
    {
        print("AudioController: PauseAudio");
        AudioListener.pause = true;
    }
    private void ResumeAudio()
    {
        print("AudioController: ResumeAudio");
        AudioListener.pause = false;
    }
}
