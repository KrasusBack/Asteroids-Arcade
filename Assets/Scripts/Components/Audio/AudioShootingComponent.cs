using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioShootingComponent : AudioComponent
{
    private void Start()
    {
        GetComponentInChildren<ShootingComponent>().Shot += PlayAudio;
    }
    
    private void PlayAudio()
    {
        audioSource.PlayOneShot(RandomAudioClip());
    }
}
