using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerAudioMovement : AudioComponentBase
{
    PlayerMovementComponent movementComponent;
    private bool playingSound = false;

    private void Start()
    {
        movementComponent = GetComponent<PlayerMovementComponent>();
    }
    // Update is called once per frame
    void Update()
    {
        if (movementComponent.Moving && !playingSound)
        {
            StartCoroutine(PlaySound());
        }
    }

    private IEnumerator PlaySound()
    {
        audioSource.PlayOneShot(audioClip);
        playingSound = true;
        yield return new WaitForSeconds(audioClip.length);
        playingSound = false;
    }
}
