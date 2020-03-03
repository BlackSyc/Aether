using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpellCastEvent : UnityEvent<SpellCast>{}
[Serializable]
public class SpellType
{
    public Spell Spell;

    [HideInInspector]
    public float coolDownUntil = 0;

    [HideInInspector]
    public UnityEvent SpellChanged;

    public SpellCastEvent NewSpellCast = new SpellCastEvent();

    public void SetSpell(Spell spell)
    {
        Spell = spell;
        SpellChanged?.Invoke();
    }

    public bool HasActiveSpell { get
        {
            return Spell != null;
        } }

    public SpellCast Cast(Transform parent)
    {
        if (Spell != null)
        {
            if (Time.time < coolDownUntil)
            {
                Debug.Log("Spell is still on cooldown!");
                return null;
            }

            SpellCast spellCast = new SpellCast(Spell, parent);
            spellCast.CastEvents.AddListener(SetCooldown);
            NewSpellCast.Invoke(spellCast);
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
