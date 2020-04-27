using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimationComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject particleEffectObj;

    private bool applicationQuiting = false;

    private void Start()
    {
        GetComponent<Destroyable>().DestroyableGonnaDestroyObject += CreateDestroyEffect;
    }

    private void CreateDestroyEffect(GameObject obj)
    {
        if (particleEffectObj && !applicationQuiting)
        {
            DeathAnimationCreator.CreateDestroyEffect(transform, particleEffectObj);
            return;
        }
        DeathAnimationCreator.CreateDestroyEffect(transform);
    }
    
    private void OnApplicationQuit()
    {
        applicationQuiting = true;
    }
}
