using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Hints/HintLoader")]
public class Hints : ScriptableObject
{
    [SerializeField]
    private List<Hint> hints;
}
