using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimationComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject particleEffectObj;

    private void OnDestroy()
    {
        if (particleEffectObj)
        {
            DeathAnimationCreator.CreateDestroyEffect(transform, particleEffectObj);
            return;
        }
        DeathAnimationCreator.CreateDestroyEffect(transform);
    }
}
