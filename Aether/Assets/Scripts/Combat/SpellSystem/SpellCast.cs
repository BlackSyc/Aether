using Aether.Core.Combat;
using System;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    internal class SpellCast : ISpellCast
    {
        #region Private Fields

        private bool casting = false;

        private ISpellObject spellObject;
        #endregion

        #region Public Properties
        public event Action<Core.Combat.ISpellCast> CastStarted;
        public event Action<float> CastProgress;
        public event Action<Core.Combat.ISpellCast> CastCancelled;
        public event Action<Core.Combat.ISpellCast> CastInterrupted;
        public event Action<Core.Combat.ISpellCast> CastComplete;

        public ICombatSystem Target { get; private set; }

        public float Progress { get; private set; } = 0f;

        public ISpell Spell { get; private set; }

        public ISpellSystem Caster { get; private set; }

        public bool CastOnSelf => Target == Caster.CombatSystem;

        public Transform CastOrigin { get; private set; }
        #endregion

        public SpellCast(ISpell spell, Transform castOrigin, ISpellSystem caster, ICombatSystem target)
        {
            this.Spell = spell;
            this.CastOrigin = castOrigin;
            this.Caster = caster;
            this.Target = target;
        }


        public void UpdateTarget(ICombatSystem newTarget)
        {
            if (newTarget == null)
                return;

            this.Target = newTarget;
            if (spellObject != null)
            {
                spellObject.SetTarget(this.Target);
            }
        }

        public void Update()
        {
            if (!casting)
                return;

            if (Progress < 1f)
            {
                if (!Spell.CastWhileMoving && Caster.MovementInterrupt)
                {
                    Cancel();
                    return;
                }

                Progress += Time.deltaTime / Spell.CastDuration;

                CastProgress?.Invoke(Progress);
            }
            else
            {
                spellObject.CastFired();
                TriggerGlobalAggro();

                casting = false;
                CastComplete?.Invoke(this);
            }
        }

        public void Cancel()
        {
            spellObject.CastCanceled();
            CastCancelled?.Invoke(this);
            casting = false;
        }

        public void Interrupt()
        {
            spellObject.CastInterrupted();
            CastInterrupted?.Invoke(this);
            Cancel();
        }

        public void Start()
        {
            spellObject = GameObject.Instantiate(ISpell.SpellObject.gameObject, CastOrigin).GetComponent<SpellObject>();

            spellObject.Spell = Spell;
            spellObject.Caster = Caster;
            spellObject.SetTarget(Target);

            spellObject.CastStarted();

            CastStarted?.Invoke(this);
            casting = true;
        }

        private void TriggerGlobalAggro()
        {
            Caster.CombatSystem.TriggerGlobalAggro(Spell.GlobalAggro);
        }
    }
}
