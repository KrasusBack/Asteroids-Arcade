using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioShooting : AudioComponentBase
{
    private void Start()
    {
        GetComponentInChildren<PlayerShootingComponent>().PlayerShoot += PlayAudio;
    }
    
    private void PlayAudio()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
