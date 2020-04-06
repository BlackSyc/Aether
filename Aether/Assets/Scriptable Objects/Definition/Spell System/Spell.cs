using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Spell System/Spell")]
[Serializable]
public class Spell : ScriptableObject
{
    public string Name;

    public Aspect Aspect;

    public SpellSlot PreferredSpellSlot;

    [TextArea(0,10)]
    public string Description;

    public float HealthDelta;

    public float CastDuration;

    public float CoolDown;

    public bool CastWhileMoving;

    public LayerMask layerMask;

    public SpellObject SpellObject;

}
