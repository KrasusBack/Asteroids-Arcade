using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class AudioComponent : MonoBehaviour
{
    [SerializeField] protected AudioClip[] audioClips;
    [SerializeField] protected AudioSource audioSource;

    /// <summary> Picks random audio clip form audioClips </summary>
    protected AudioClip RandomAudioClip()
    {
        if (audioClips.Length == 0) return null;
        return audioClips[Random.Range(0, audioClips.Length)];
    }
}
