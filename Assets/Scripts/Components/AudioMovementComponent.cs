using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AudioMovementComponent : AudioComponent
{
    [SerializeField, Min(0)] private float timeToMaxSound = 1.0f;
    [SerializeField, Range(0, 1), Tooltip("Percent value based on current volume")]
    private float startSoundVolumePart = 0.3f;

    private float maxSoundVolume;

    IMoving movementComponent;

    public float StartSoundVolumePart { get => startSoundVolumePart; set => startSoundVolumePart = value; }

    private void Start()
    {
        movementComponent = GetComponent<IMoving>();
        maxSoundVolume = audioSource.volume;
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
        audioSource.volume = startSoundVolumePart * maxSoundVolume;
        StopAllCoroutines();
    }

    private IEnumerator ChangeVolumeOverTime()
    {
        var endingTime = Time.time + timeToMaxSound;
        audioSource.volume = startSoundVolumePart * maxSoundVolume;
        yield return new WaitForEndOfFrame();

        while (Time.time < endingTime)
        {
            audioSource.volume += Time.deltaTime / timeToMaxSound * maxSoundVolume;
            print(audioSource.volume + " left:" + (endingTime - Time.time));
            yield return new WaitForEndOfFrame();
        }
    }
}
