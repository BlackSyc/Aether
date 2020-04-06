using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpellLibrary
{
    public event Action<Spell> OnActiveSpellChanged;

    [SerializeField]
    private Spell activeSpell;

    public Spell ActiveSpell => activeSpell;

    [SerializeField]
    private List<Spell> library;


    private float coolDownUntil;

    public float CoolDownUntil => coolDownUntil;

    public void SetActiveSpell(Spell spell)
    {
        if (spell == null)
            return;

        if (!library.Contains(spell))
            library.Add(spell);

        activeSpell = spell;
        OnActiveSpellChanged?.Invoke(ActiveSpell);
    }

    public void Remove(Spell spell)
    {
        library.Remove(spell);

        if (ActiveSpell.Equals(spell))
        {
            activeSpell = null;
            OnActiveSpellChanged?.Invoke(null);
        }
    }

    public bool HasActiveSpell => ActiveSpell != null;

    public bool Cast(out SpellCast spellCast, Transform parent, TargetManager targetManager)
    {
        spellCast = null;

        if (ActiveSpell == null)
            return false;

        if (Time.time < coolDownUntil)
            return false;

        SpellCast newSpellCast = new SpellCast(ActiveSpell, parent, targetManager);
        newSpellCast.CastComplete += SetCoolDown;
        spellCast = newSpellCast;
        return true;
    }

    private void SetCoolDown(SpellCast spellCast)
    {
        coolDownUntil = Time.time + spellCast.Spell.CoolDown;
    }
}
