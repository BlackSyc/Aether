using Aether.Core.Combat.ScriptableObjects;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    internal abstract class SpellObject : MonoBehaviour, ISpellObject
    {
        public Spell Spell { get; set; }

        public ISpellSystem Caster { get; set; }

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
