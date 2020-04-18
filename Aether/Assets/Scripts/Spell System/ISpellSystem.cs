using Aether.SpellSystem.ScriptableObjects;
using System;
using UnityEngine;

namespace Aether.SpellSystem
{
    public interface ISpellSystem
    {
        #region Properties
        event Action<ISpellLibrary> OnActiveSpellChanged;
        event Action<SpellCast> OnSpellIsCast;

        bool HasActiveSpells { get; }

        bool IsCasting { get; }

        ISpellLibrary[] SpellLibraries { get; }

        Transform CastParent { get; }

        GameObject gameObject { get; }
        #endregion

        #region Methods
        void AddSpell(int libraryIndex, Spell spell, bool makeActive = true);

        void RemoveSpell(int libraryIndex, Spell spell);

        void CastSpell(int index);

        void CancelSpellCast();

        void InterruptSpellCast();

        LayerMask GetCombinedLayerMask();
        #endregion
    }
}