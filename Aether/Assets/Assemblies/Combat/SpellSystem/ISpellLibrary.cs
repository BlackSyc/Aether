using System;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    internal interface ISpellLibrary : Core.Combat.ISpellLibrary
    {
        #region Properties
        float CoolDownUntil { get; }

        bool IsOnCoolDown { get; }

        bool HasActiveSpell { get; }
        #endregion

        #region Methods
        bool TryCast(out SpellCast spellCast, Transform castParent, ISpellSystem caster, ICombatSystem target);
        #endregion
    }
}