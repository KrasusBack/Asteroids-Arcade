using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AudioDestroyerComponent : AudioComponent
{
    private void Start()
    {
        GetComponent<Destroyable>().DestroyableGonnaDestroyObject += CreateDestroyEffect;
        //AudioDestroyerSource - object which plays destroy sounds of objects
        audioSource = GameObject.Find("AudioDestroyerSource")?.GetComponent<AudioSource>();
    }

    private void CreateDestroyEffect(GameObject obj)
    {
        if (Application.isPlaying) audioSource?.PlayOneShot(RandomAudioClip());
    }
}
