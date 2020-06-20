using Aether.Core.Combat;
using System;
using UnityEngine;

namespace Aether.ScriptableObjects.Modifiers
{
    [Serializable]
    public abstract class AttributeModifierBehaviour : MonoBehaviour
    {
        protected ISpellCast spellCast;

        public void Link(ISpellCast spellCast)
        {
            this.spellCast = spellCast;

            spellCast.CastStarted += CastStarted;
            spellCast.CastComplete += CastCompleted;
            spellCast.CastCancelled += CastCanceled;
            spellCast.CastInterrupted += CastInterrupted;
            spellCast.CastProgress += CastProgress;
        }

        protected virtual void CastProgress(float progress)
        {

        }

        protected virtual void CastInterrupted(ISpellCast spellCast)
        {
            Destroy(gameObject);
        }

        protected virtual void CastCanceled(ISpellCast spellCast)
        {
            Destroy(gameObject);
        }

        protected abstract void CastCompleted(ISpellCast spellCast);

        protected abstract void CastStarted(ISpellCast spellCast);

        protected void OnDestroy()
        {
            spellCast.CastStarted -= CastStarted;
            spellCast.CastInterrupted -= CastInterrupted;
            spellCast.CastCancelled -= CastCanceled;
            spellCast.CastComplete -= CastCompleted;
            spellCast.CastProgress -= CastProgress;
        }
    }
}
