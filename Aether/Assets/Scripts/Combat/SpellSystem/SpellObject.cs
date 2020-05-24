using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    public abstract class SpellObject : MonoBehaviour
    {
        [HideInInspector]
        public Spell Spell;

        [HideInInspector]
        public ISpellSystem Caster;

        [HideInInspector]
        public ICombatSystem Target { get; protected set; }

        public virtual void SetTarget(ICombatSystem newTarget)
        {
            Target = newTarget;
        }

        public abstract void CastStarted();

        public abstract void CastInterrupted();

        public abstract void CastCanceled();

        public abstract void CastFired();
    }
}
