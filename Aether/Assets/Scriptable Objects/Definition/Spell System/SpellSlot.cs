using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Spell System/SpellSlot")]
[Serializable]
public class SpellSlot : ScriptableObject
{
    public event Action<Spell> OnSpellChanged;

    public void SpellChanged(Spell newSpell)
    {
        OnSpellChanged?.Invoke(newSpell);
    }

    public string Name;

    public SpellSlotState State = new SpellSlotState();
    public struct SpellSlotState
    {
        public Spell Spell;

        public float CoolDownUntil;
    }

    public void SelectSpell(Spell spell)
    {
        if (spell == null)
        {
            RemoveSpell();
            return;
        }

        if (spell.PreferredSpellSlot != this)
            return;

        State.Spell = spell;
        SpellChanged(spell);
    }

    public void RemoveSpell()
    {
        State.Spell = null;
        SpellChanged(null);
    }

    public bool HasActiveSpell { get
        {
            return State.Spell != null;
        } }

    public SpellCast Cast(Transform parent, TargetManager targetManager)
    {
        if (State.Spell == null)
            return null;

        if (Time.time < State.CoolDownUntil)
        {
            Debug.Log("Spell is still on cooldown!");
            return null;
        }

        SpellCast spellCast = new SpellCast(State.Spell, parent, targetManager);
        spellCast.CastComplete += SetCoolDown;
        return spellCast;
    }

    private void SetCoolDown(SpellCast spellCast)
    {
        State.CoolDownUntil = Time.time + spellCast.Spell.CoolDown;
    }
}
