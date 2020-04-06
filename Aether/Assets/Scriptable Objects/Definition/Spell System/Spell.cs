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

    [TextArea(0,10)]
    public string Description;

    public float Damage;

    public float Heal;

    public int GlobalAggro;

    public float LocalAggro;

    public float CastDuration;

    public float CoolDown;

    public bool CastWhileMoving;

    public LayerMask layerMask;

    public SpellObject SpellObject;

}
