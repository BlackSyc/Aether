using System;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    public interface ISpellLibrary
    {
        #region Properties
        event Action<Spell> OnActiveSpellChanged;

        Spell ActiveSpell { get; }

        float CoolDownUntil { get; }

        bool IsOnCoolDown { get; }

        bool HasActiveSpell { get; }
        #endregion

        #region Methods
        bool Contains(Spell spell);

        void Remove(Spell spell);

        void Add(Spell spell, bool makeActive = true);

        bool TryCast(out SpellCast spellCast, Transform castParent, ISpellSystem caster, ICombatSystem target);
        #endregion
    }
}