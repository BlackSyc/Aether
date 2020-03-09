using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/Spell System/SpellSlot")]
[Serializable]
public class SpellSlot : ScriptableObject
{
    public string Name;

    public SpellSlotState State = new SpellSlotState();

    public Spell prefillSpell;

    public struct SpellSlotState
    {
        public Spell Spell;

        public float CoolDownUntil;
    }

    public void Initialize()
    {
        AetherEvents.GameEvents.SpellSystemEvents.OnGrantNewSpell += SelectSpell;
        SelectSpell(prefillSpell);
    }

    public void SelectSpell(Spell spell)
    {
        if (spell == null)
            return;

        if (spell.SpellSlot != this)
            return;

        State.Spell = spell;
        AetherEvents.GameEvents.SpellSystemEvents.NewSpellSelected(spell);
    }

    public bool HasActiveSpell { get
        {
            return State.Spell != null;
        } }

    public SpellCast Cast(Transform parent, TargetManager targetManager)
    {
        if (State.Spell != null)
        {
            if (Time.time < State.CoolDownUntil)
            {
                Debug.Log("Spell is still on cooldown!");
                return null;
            }

            SpellCast spellCast = new SpellCast(State.Spell, parent, targetManager);
            spellCast.CastComplete += SetCoolDown;
            return spellCast;
        }
        else
        {
            Debug.LogWarning("No spell bound to this spell slot!");
            return null;
        }
    }

    private void SetCoolDown(SpellCast spellCast)
    {
        State.CoolDownUntil = Time.time + spellCast.Spell.CoolDown;
    }

    private void OnDisable()
    {
        AetherEvents.GameEvents.SpellSystemEvents.OnGrantNewSpell -= SelectSpell;
    }
}
