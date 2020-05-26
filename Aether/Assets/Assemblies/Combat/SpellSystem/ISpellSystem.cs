using System;
using UnityEngine;

namespace Aether.Combat.SpellSystem { 
    internal interface ISpellSystem : Core.Combat.ISpellSystem
    {
        #region Properties
        event Action<ISpellLibrary> OnActiveSpellChanged;
        event Action<ISpellCast> OnSpellIsCast;

        bool HasActiveSpells { get; }

        bool IsCasting { get; }

        ISpellLibrary[] SpellLibraries { get; }

        Transform CastOrigin { get; }

        bool MovementInterrupt { get; }

        ICombatSystem CombatSystem { get; }
        #endregion

        #region Methods

        void CastSpell(int index);

        void CancelSpellCast();

        void InterruptSpellCast();

        LayerMask GetCombinedLayerMask();
        #endregion
    }
}