using Aether.Core.Combat;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    internal interface ISpellLibrary : Core.Combat.ISpellLibrary
    {
        #region Properties
        float CoolDownUntil { get; }

        bool IsOnCoolDown { get; }

        bool IsOnGlobalCoolDown { get; }

        new bool HasActiveSpell { get; }
        #endregion

        #region Methods
        bool TryCast(out SpellCast spellCast, Transform castParent, ICombatSystem caster, Target target);

        void RemoveAll();
        #endregion
    }
}