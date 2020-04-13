using UnityEngine;

[CreateAssetMenu(fileName = "PrefabReferences", menuName = "ScriptableObjects/PrefabReferences", order = 7)]

public class PrefabReferences : ScriptableObject
{
    [SerializeField]
    private GameObject bulletBasePrefab;
    [SerializeField]
    private GameObject commonDestroyParticleEffect;
    [SerializeField]
    private GameObject playerDestroyParticleEffect;

    #region Public Getters

    public GameObject BulletBasePrefab
    {
        get => bulletBasePrefab;
    }
    public GameObject CommonDestroyParticleEffect
    {
        get => commonDestroyParticleEffect;
    }
    public GameObject PlayerDestroyParticleEffect
    {
        get => playerDestroyParticleEffect;
    }
    #endregion

}
