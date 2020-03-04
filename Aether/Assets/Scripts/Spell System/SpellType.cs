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

    public delegate void SpellChangedEventHandler(SpellType spellType);
    public event SpellChangedEventHandler SpellChanged;

    public delegate void NewSpellCastEventHandler(SpellCast spellCast);
    public event NewSpellCastEventHandler NewSpellCast;

    public void SetSpell(Spell spell)
    {
        Spell = spell;
        SpellChanged?.Invoke(this);
    }

    public bool HasActiveSpell { get
        {
            return Spell != null;
        } }

    public SpellCast Cast(Transform parent, TargetManager targetManager)
    {
        if (Spell != null)
        {
            if (Time.time < coolDownUntil)
            {
                Debug.Log("Spell is still on cooldown!");
                return null;
            }

            SpellCast spellCast = new SpellCast(Spell, parent, targetManager);
            spellCast.CastComplete += x => coolDownUntil = Time.time + x.Spell.CoolDown;
            NewSpellCast?.Invoke(spellCast);
            return spellCast;
        }
        else
        {
            Debug.LogWarning("No spell bound to this spell slot!");
            return null;
        }
    }
}
