using Aether.Core.Combat;
using UnityEngine;

namespace Aether.Combat.SpellSystem.SpellBehaviours
{
    public abstract class SpellBehaviour : MonoBehaviour
    {
        public ISpell Spell { get; set; }

        public Core.Combat.ICombatSystem Caster { get; set; }

        [HideInInspector]
        public Target Target { get; protected set; }

        public virtual void SetTarget(Target newTarget)
        {
            Target = newTarget;
        }

        public abstract void CastStarted();

        public abstract void CastInterrupted();

        public abstract void CastCanceled();

        public abstract void CastFired();
    }
}
