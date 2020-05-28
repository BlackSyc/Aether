using Aether.Core.Combat.ScriptableObjects;
using System;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    internal interface ISpellCast : Core.Combat.ISpellCast
    {
        #region Public Properties
        event Action<ISpellCast> CastStarted;
        event Action<float> CastProgress;
        event Action<ISpellCast> CastCancelled;
        event Action<ISpellCast> CastInterrupted;
        event Action<ISpellCast> CastComplete;

        ICombatSystem Target { get; }

        float Progress { get; }

        Spell Spell { get; }

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
