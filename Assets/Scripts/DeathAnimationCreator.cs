using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeathAnimationCreator : MonoBehaviour
{
    public static void CreatePlayerDeathEffect()
    {
        if (!GameCore.Instance) return;
        Instantiate(GameCore.Instance.PrefabReferences.PlayerDestroyParticleEffect,
                    GameCore.Instance.PlayerShip.transform.position,
                    GameCore.Instance.PlayerShip.transform.rotation);
    }

    //call for default effect
    public static void CreateDestroyEffect(Transform objTransform)
    {
        CreateDestroyEffect(objTransform, GameCore.Instance?.PrefabReferences.CommonDestroyParticleEffect);
    }

    public static void CreateDestroyEffect(Transform objTransform, GameObject destroyEffectObj)
    {
        var effectObj = Instantiate(destroyEffectObj, objTransform.position, objTransform.rotation);
        //aply destroying obj scale
        Vector3 newScale = new Vector3(objTransform.localScale.x * effectObj.transform.localScale.x,
                                       objTransform.localScale.y * effectObj.transform.localScale.y,
                                       objTransform.localScale.z * effectObj.transform.localScale.z);
        effectObj.transform.localScale = newScale;
    }
}
