using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public abstract class AudioComponentBase : MonoBehaviour
{
    [SerializeField]
    protected AudioClip audioClip;

    protected  AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
