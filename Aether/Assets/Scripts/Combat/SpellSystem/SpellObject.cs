using Aether.Core.Combat;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    public abstract class SpellObject : MonoBehaviour, ISpellObject
    {
        public ISpell Spell { get; set; }

        public Core.Combat.ICombatSystem Caster { get; set; }

        [HideInInspector]
        public Core.Combat.ICombatSystem Target { get; protected set; }

        public virtual void SetTarget(Core.Combat.ICombatSystem newTarget)
        {
            Target = newTarget;
        }

        public abstract void CastStarted();

        public abstract void CastInterrupted();

        public abstract void CastCanceled();

        public abstract void CastFired();
    }
}
