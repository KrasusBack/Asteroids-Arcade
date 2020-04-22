using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AudioMovementComponent : AudioComponent
{
    private const float timeToMaxSound = 1.0f;
    private const float startSoundVolume = 0.15f;

    IMoving movementComponent;

    private void Start()
    {
        movementComponent = GetComponent<IMoving>();
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.volume = 0;
    }

    void Update()
    {
        if (movementComponent.Moving)
        {
            if (!audioSource.isPlaying)
            {
                StartCoroutine(ChangeVolumeOverTime());
                audioSource.Play();
            }
            return;
        }
        ResetAudio();
    }

    private void ResetAudio()
    {
        audioSource.Pause();
        audioSource.volume = startSoundVolume;
        StopAllCoroutines();
    }

    private IEnumerator ChangeVolumeOverTime()
    {
        var endingTime = Time.time + timeToMaxSound;
        audioSource.volume = startSoundVolume;
        yield return new WaitForEndOfFrame();

        while (Time.time < endingTime)
        {
            audioSource.volume += Time.deltaTime / timeToMaxSound;
            yield return new WaitForEndOfFrame();
        }
    }
}
