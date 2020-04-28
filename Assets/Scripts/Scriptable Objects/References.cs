using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "References", menuName = "ScriptableObjects/References", order = 7)]
public class References : ScriptableObject
{
    [SerializeField] private AsteroidsSettings asteroidsSettings;
    [SerializeField] private PlayerShipSettings playerShipSettings;
    [SerializeField] private SaucersSettings saucersSettings;
    [SerializeField] private PointsSettings pointsSettings;
    [SerializeField] private InputSettings inputSettings;
    [SerializeField] private LevelSettings levelSettings;
    [SerializeField] private PrefabReferences prefabReferences;

    #region PublicGetters
    public AsteroidsSettings AsteroidsSettings => asteroidsSettings;
    public PlayerShipSettings PlayerShipSettings => playerShipSettings;
    public SaucersSettings SaucersSettings => saucersSettings;
    public PointsSettings PointsSettings => pointsSettings;
    public InputSettings InputSettings => inputSettings;
    public LevelSettings LevelSettings => levelSettings;
    public PrefabReferences PrefabReferences => prefabReferences;
    #endregion
}
