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

    private float coolDownUntil;

    public void SetCoolDownUntil(float coolDownUntil)
    {
        this.coolDownUntil = coolDownUntil;
    }

    public float getCoolDownUntil()
    {
        return this.coolDownUntil;
    }




}
