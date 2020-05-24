using Aether.SpellSystem.ScriptableObjects;
using Aether.TargetSystem;
using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace Aether.SpellSystem
{
    public interface ISpellSystem : ICombatComponent
    {
        #region Properties
        event Action<ISpellLibrary> OnActiveSpellChanged;
        event Action<SpellCast> OnSpellIsCast;

        bool HasActiveSpells { get; }

        bool IsCasting { get; }

        ISpellLibrary[] SpellLibraries { get; }

        Transform CastOrigin { get; }

        bool MovementInterrupt { get; }
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