using Aether.SpellSystem.ScriptableObjects;
using Aether.TargetSystem;
using UnityEngine;

namespace Aether.SpellSystem
{
    public abstract class SpellObject : MonoBehaviour
    {
        [HideInInspector]
        public Spell Spell;

        [HideInInspector]
        public ISpellSystem Caster;

        [HideInInspector]
        public ICombatComponent Target { get; protected set; }

        public virtual void SetTarget(ICombatComponent newTarget)
        {
            Target = newTarget;
        }

        public abstract void CastStarted();

        public abstract void CastInterrupted();

        public abstract void CastCanceled();

        public abstract void CastFired();
    }
}
