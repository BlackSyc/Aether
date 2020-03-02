using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Spell System/Spell")]
public class Spell : ScriptableObject
{
    public string Name;

    public float castDuration;

    public float coolDown;

    public SpellObject SpellObject;
}
