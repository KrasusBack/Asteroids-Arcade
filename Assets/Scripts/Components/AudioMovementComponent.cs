using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AudioMovementComponent : AudioComponent
{
    IMoving movementComponent;

    private void Start()
    {
        movementComponent = GetComponent<IMoving>();
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
