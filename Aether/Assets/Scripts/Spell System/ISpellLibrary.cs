using Aether.Spells.ScriptableObjects;
using System;
using UnityEngine;

namespace Aether.Spells
{
    public interface ISpellLibrary
    {
        #region Properties
        event Action<Spell> OnActiveSpellChanged;

        Spell ActiveSpell { get; }

        float CoolDownUntil { get; }

        bool HasActiveSpell { get; }
        #endregion

        #region Methods
        bool Contains(Spell spell);

        void Remove(Spell spell);

        void Add(Spell spell, bool makeActive = true);

        bool TryCast(out SpellCast spellCast, Transform castParent, ISpellSystem caster, TargetManager targetManager, bool onSelf);
        #endregion
    }
}