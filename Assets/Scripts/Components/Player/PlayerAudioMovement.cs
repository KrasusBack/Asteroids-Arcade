using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerAudioMovement : AudioComponent
{
    PlayerMovementComponent movementComponent;

    private void Start()
    {
        movementComponent = GetComponent<PlayerMovementComponent>();
        audioSource.clip = audioClip;
    }

    void Update()
    {
        if (movementComponent.Moving)
        {
            if (!audioSource.isPlaying) audioSource.Play();
            return;
        }
        audioSource.Stop();
    }
}
