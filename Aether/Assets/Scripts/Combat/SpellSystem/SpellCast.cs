using Aether.Core.Combat;
using System;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    internal class SpellCast : ISpellCast
    {
        #region Private Fields

        private bool casting = false;
        #endregion

        #region Public Properties
        public event Action<Core.Combat.ISpellCast> CastStarted;
        public event Action<float> CastProgress;
        public event Action<Core.Combat.ISpellCast> CastCancelled;
        public event Action<Core.Combat.ISpellCast> CastInterrupted;
        public event Action<Core.Combat.ISpellCast> CastComplete;
        public event Action<Target> TargetChanged;

        public Target Target { get; private set; }

        public float Progress { get; private set; } = 0f;

        public ISpell Spell { get; private set; }

        public Core.Combat.ICombatSystem Caster { get; private set; }

        public bool CastOnSelf => Target == Caster;

        public Transform CastOrigin { get; private set; }
        #endregion

        public SpellCast(ISpell spell, Transform castOrigin, ICombatSystem caster, Target target)
        {
            this.Spell = spell;
            this.CastOrigin = castOrigin;
            this.Caster = caster;
            this.Target = target;
        }


        public void UpdateTarget(Target newTarget)
        {
            if (newTarget == null)
                return;

            if (Target.HasCombatTarget() && !newTarget.HasCombatTarget())
                return;

            if (Spell.RequiresCombatTarget && !newTarget.HasCombatTarget())
                return;

            Target = newTarget;

            TargetChanged?.Invoke(newTarget);
        }

        public void Update()
        {
            if (!casting)
                return;

            if (Progress < 1f)
            {
                if (!Spell.CastWhileMoving && Caster.Get<ISpellSystem>().MovementInterrupt)
                {
                    Cancel();
                    return;
                }

                if (Caster.Has(out Attributes attributes))
                    Progress += (Time.deltaTime / Spell.CastDuration) * (attributes.Haste / 100);
                else
                    Progress += Time.deltaTime / Spell.CastDuration;

                CastProgress?.Invoke(Progress);
            }
            else
            {
                TriggerGlobalAggro();
                casting = false;
                CastComplete?.Invoke(this);
            }
        }

        public void Cancel()
        {
            CastCancelled?.Invoke(this);
            casting = false;
        }

        public void Interrupt()
        {
            CastInterrupted?.Invoke(this);
            Cancel();
        }

        public void Start()
        {
            Spell.Initialize(this);

            CastStarted?.Invoke(this);
            casting = true;
        }

        private void TriggerGlobalAggro()
        {
            Caster.TriggerGlobalAggro(Spell.GlobalAggro);
        }
    }
}
