using Aether.Core.Combat;
using System.Collections.Generic;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    internal interface ISpellSystem : Core.Combat.ISpellSystem
    {
        #region Properties

        bool IsCasting { get; }

        List<ISpellLibrary> SpellLibraries { get; }

        Transform CastOrigin { get; }

        bool MovementInterrupt { get; }

        ICombatSystem CombatSystem { get; }
        #endregion

        #region Methods

        new void CastSpell(int index, Target target);

        void CancelSpellCast();

        void InterruptSpellCast();
        #endregion
    }
}