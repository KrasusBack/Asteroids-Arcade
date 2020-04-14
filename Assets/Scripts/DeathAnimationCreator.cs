using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeathAnimationCreator : MonoBehaviour
{
    public static void CreatePlayerDeathEffect()
    {
        Instantiate(GameCore.Instance.PrefabReferences.PlayerDestroyParticleEffect,
                    GameCore.Instance.PlayerShip.transform.position,
                    GameCore.Instance.PlayerShip.transform.rotation);
    }

    public static void CreateSomeDestroyEffect(Transform objTransform)
    {
        var effectObj = Instantiate(GameCore.Instance.PrefabReferences.CommonDestroyParticleEffect,
                                    objTransform.position,
                                    objTransform.rotation);
        Vector3 newScale = new Vector3(objTransform.localScale.x * effectObj.transform.localScale.x,
                                       objTransform.localScale.y * effectObj.transform.localScale.y,
                                       objTransform.localScale.z * effectObj.transform.localScale.z);
        effectObj.transform.localScale = newScale;
    }
}
