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
        private bool castCancelled = false;

        private ISpellSystem caster;

        private Target target;

        private Transform castOrigin;

        private SpellObject spellObject;
        #endregion

        #region Public Properties
        public event Action<SpellCast> CastStarted;
        public event Action<float> CastProgress;
        public event Action<SpellCast> CastCancelled;
        public event Action<SpellCast> CastInterrupted;
        public event Action<SpellCast> CastComplete;

        public float Progress { get; private set; } = 0f;

        public Spell Spell { get; private set; }
        #endregion



        public SpellCast(Spell spell, Transform castOrigin, ISpellSystem caster, Target target)
        {
            Spell = spell;
            this.castOrigin = castOrigin;
            this.caster = caster;
            this.target = target;
        }

        public void UpdateTarget(Target newTarget)
        {
            this.target = newTarget;
            if (spellObject)
            {
                spellObject.Target = this.target;
            }
        }

        public IEnumerator Start()
        {
            spellObject = GameObject.Instantiate(Spell.SpellObject.gameObject, castOrigin).GetComponent<SpellObject>();

            spellObject.Spell = Spell;
            spellObject.Caster = caster;
            spellObject.Target = target;

            spellObject.CastStarted();
            CastStarted?.Invoke(this);

            while (Progress < 1f)
            {
                if (castCancelled)
                    yield break;

                if (!Spell.CastWhileMoving && Player.Instance.PlayerMovement.IsMoving)
                {
                    Cancel();
                    yield break;
                }

                Progress += Time.deltaTime / Spell.CastDuration;

                CastProgress?.Invoke(Progress);
                yield return null;
            }

            spellObject.CastFired();

            CastComplete?.Invoke(this);
        }

        public void Cancel()
        {
            spellObject.CastCanceled();
            CastCancelled?.Invoke(this);
            castCancelled = true;
        }

        public void Interrupt()
        {
            spellObject.CastInterrupted();
            CastInterrupted?.Invoke(this);
            Cancel();
        }
    }
}
