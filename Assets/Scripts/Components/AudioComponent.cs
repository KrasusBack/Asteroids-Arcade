using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public abstract class AudioComponent : MonoBehaviour
{
    [SerializeField] protected AudioClip audioClip;
    [SerializeField] protected AudioSource audioSource;
}
