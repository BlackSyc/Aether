using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpellSlot
{
    public Spell spell;

    public float coolDownUntil;

    public bool HasActiveSpell { get
        {
            return spell != null;
        } }

    public SpellCast Cast(Transform parent)
    {
        if (spell != null)
        {
            if (Time.time < coolDownUntil)
            {
                Debug.Log("Spell is still on cooldown!");
                return null;
            }

            SpellCast spellCast = new SpellCast(spell, parent);
            spellCast.CastEvents.AddListener(SetCooldown);
            return spellCast;
        }
        else
        {
            Debug.LogWarning("No spell bound to this spell slot!");
            return null;
        }
    }


    public void SetCooldown(EventType castEvent, SpellCast spellCast)
    {
        if (castEvent == EventType.CastComplete)
        {
            coolDownUntil = Time.time + spellCast.spell.coolDown;
        }
    }
}
