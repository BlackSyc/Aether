using Aether.Core.Combat;
using System;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    internal interface ISpellCast : Core.Combat.ISpellCast
    {
        #region Public Properties

        ICombatSystem Target { get; }

        float Progress { get; }

        ISpell Spell { get; }

        ISpellSystem Caster { get; }

        bool CastOnSelf { get; }

        Transform CastOrigin { get; }
        #endregion


        void UpdateTarget(ICombatSystem newTarget);

        void Cancel();

        void Interrupt();

        void Update();

        void Start();
    }
}
