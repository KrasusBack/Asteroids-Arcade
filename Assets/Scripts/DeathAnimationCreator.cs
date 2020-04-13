using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimationCreator : MonoBehaviour
{
    public static void CreatePlayerDeathEffect()
    {
        Instantiate(GameCore.Instance.PrefabReferences.PlayerDestroyParticleEffect,
                    GameCore.Instance.PlayerShip.transform.position, Quaternion.identity);
    }
}
