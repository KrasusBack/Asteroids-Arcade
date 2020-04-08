using UnityEngine;

[CreateAssetMenu(fileName = "InputSettings", menuName = "ScriptableObjects/InputSettings", order = 6)]

public class InputSettings : ScriptableObject
{
    [Header("PlayerShip control keys")]
    [SerializeField]
    private KeyCode fireKey = KeyCode.Space;
    [SerializeField]
    private KeyCode hyperSpaceKey = KeyCode.LeftShift;
    
    #region Public Getters

    public KeyCode FireKey
    {
        get => fireKey;
    }

    public KeyCode HyperSpaceKey
    {
        get => hyperSpaceKey;
    }

    #endregion
}
