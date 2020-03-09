using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Spell System/Spell")]
[Serializable]
public class Spell : ScriptableObject
{
    public string Name;

    public SpellSlot SpellSlot;

    public float CastDuration;

    public float CoolDown;

    public bool CastWhileMoving;

    public LayerMask layerMask;

    public SpellObject SpellObject;

}
