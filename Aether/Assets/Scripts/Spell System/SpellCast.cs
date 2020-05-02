using Aether.SpellSystem.ScriptableObjects;
using Aether.TargetSystem;
using System;
using System.Collections;
using UnityEngine;

namespace Aether.SpellSystem
{
    public class SpellCast
    {
        #region Private Fields

        private bool casting = false;

        private SpellObject spellObject;
        #endregion

        #region Public Properties
        public event Action<SpellCast> CastStarted;
        public event Action<float> CastProgress;
        public event Action<SpellCast> CastCancelled;
        public event Action<SpellCast> CastInterrupted;
        public event Action<SpellCast> CastComplete;

        public Target Target { get; private set; }

        public float Progress { get; private set; } = 0f;

        public Spell Spell { get; private set; }

        public ISpellSystem Caster { get; private set; }

        public bool CastOnSelf => Target.TargetTransform == Caster.gameObject.transform;

        public Transform CastOrigin { get; private set; }
        #endregion



        public SpellCast(Spell spell, Transform castOrigin, ISpellSystem caster, Target target)
        {
            this.Spell = spell;
            this.CastOrigin = castOrigin;
            this.Caster = caster;
            this.Target = target;
        }

        public void UpdateTarget(Target newTarget)
        {
            this.Target = newTarget;
            if (spellObject)
            {
                spellObject.Target = this.Target;
            }
        }

        internal void Update()
        {
            if (!casting)
                return;

            if (Progress < 1f)
            {
                if (!Spell.CastWhileMoving && Caster.gameObject.GetComponent<IMovementSystem>().IsMoving)
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

        internal void Start()
        {
            spellObject = GameObject.Instantiate(Spell.SpellObject.gameObject, CastOrigin).GetComponent<SpellObject>();

            spellObject.Spell = Spell;
            spellObject.Caster = Caster;
            spellObject.Target = Target;

            spellObject.CastStarted();

            CastStarted?.Invoke(this);
            casting = true;
        }

        private void TriggerGlobalAggro()
        {
            AggroTrigger aggroTrigger = Caster.gameObject.GetComponent<AggroTrigger>();

            if (aggroTrigger == null)
                return;

            aggroTrigger.TriggerGlobalAggro(Spell.GlobalAggro);

        }
    }
}
