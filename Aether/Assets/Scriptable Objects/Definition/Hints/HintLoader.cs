using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Hints/HintLoader")]
public class HintLoader : ScriptableObject
{
    [SerializeField]
    private List<Hint> hints;
}
