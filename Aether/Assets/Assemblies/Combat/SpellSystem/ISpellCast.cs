using Aether.Core.Combat.ScriptableObjects;
using System;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    internal interface ISpellCast : Core.Combat.ISpellCast
    {
        #region Public Properties
        public event Action<ISpellCast> CastStarted;
        public event Action<float> CastProgress;
        public event Action<ISpellCast> CastCancelled;
        public event Action<ISpellCast> CastInterrupted;
        public event Action<ISpellCast> CastComplete;

        public ICombatSystem Target { get; }

        public float Progress { get; }

        public Spell Spell { get; }

        public ISpellSystem Caster { get; }

        public bool CastOnSelf { get; }

        public Transform CastOrigin { get; }
        #endregion


        public void UpdateTarget(ICombatSystem newTarget);

        public void Cancel();

        public void Interrupt();

        public void Update();

        public void Start();
    }
}
