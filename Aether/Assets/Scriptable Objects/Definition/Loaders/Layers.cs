using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Loaders/Layers")]
public class Layers : ScriptableObject
{
    [SerializeField]
    private LayerMask obstructionLayer;

    public static LayerMask ObstructionLayer { get; private set; }

    private void OnEnable()
    {
        ObstructionLayer = obstructionLayer;
    }
}
