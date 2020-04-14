using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimationComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject particleEffectObj;

    private bool applicationQuiting = false;

    private void OnDisable()
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
        print("DestroyAnimationComponent: quit");
        applicationQuiting = true;
    }
}
