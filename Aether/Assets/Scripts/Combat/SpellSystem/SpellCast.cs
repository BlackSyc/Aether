using Aether.Combat.SpellSystem.SpellBehaviours;
using Aether.Core.Combat;
using System;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    internal class SpellCast : ISpellCast
    {
        #region Private Fields

        private bool casting = false;

        private SpellBehaviour spellBehaviour;
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

        public ICombatSystem Caster { get; private set; }

        public bool CastOnSelf => Target == Caster;

        public Transform CastOrigin { get; private set; }
        #endregion

        public SpellCast(ISpell spell, Transform castOrigin, ICombatSystem caster, ICombatSystem target)
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
            if (spellBehaviour != null)
            {
                spellBehaviour.SetTarget(this.Target);
            }
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

                Progress += Time.deltaTime / Spell.CastDuration;

                CastProgress?.Invoke(Progress);
            }
            else
            {
                spellBehaviour.CastFired();
                TriggerGlobalAggro();

                casting = false;
                CastComplete?.Invoke(this);
            }
        }

        public void Cancel()
        {
            spellBehaviour.CastCanceled();
            CastCancelled?.Invoke(this);
            casting = false;
        }

        public void Interrupt()
        {
            spellBehaviour.CastInterrupted();
            CastInterrupted?.Invoke(this);
            Cancel();
        }

        public void Start()
        {
            spellBehaviour = GameObject.Instantiate(Spell.SpellPrefab, CastOrigin).GetComponent<SpellBehaviour>();

            spellBehaviour.Spell = Spell;
            spellBehaviour.Caster = Caster;
            spellBehaviour.SetTarget(Target);

            spellBehaviour.CastStarted();

            CastStarted?.Invoke(this);
            casting = true;
        }

        private void TriggerGlobalAggro()
        {
            Caster.TriggerGlobalAggro(Spell.GlobalAggro);
        }
    }
}
