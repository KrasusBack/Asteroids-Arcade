using UnityEngine;

[CreateAssetMenu(fileName = "PrefabReferences", menuName = "ScriptableObjects/PrefabReferences", order = 7)]

public class PrefabReferences : ScriptableObject
{
    [SerializeField]
    private GameObject bulletBasePrefab;


    #region Public Getters

    public GameObject BulletBasePrefab
    {
        get => bulletBasePrefab;
    }

    #endregion

}
