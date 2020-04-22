using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AudioDestroyerComponent : AudioComponent
{
    private void Awake()
    {
        audioSource = GameObject.Find("AudioDestroyerSource").GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        if (Application.isPlaying) audioSource?.PlayOneShot(audioClip);
    }
}
