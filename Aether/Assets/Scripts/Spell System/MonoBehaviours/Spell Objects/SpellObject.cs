using Aether.SpellSystem.ScriptableObjects;
using Aether.TargetSystem;
using UnityEngine;

namespace Aether.SpellSystem
{
    public class SpellObject : MonoBehaviour
    {
        public Spell Spell;

        public ISpellSystem Caster;

        public Target Target;

        public virtual void CastStarted() { }

        public virtual void CastInterrupted() { }

        public virtual void CastCanceled() { }

        public virtual void CastFired()
        {
            AggroTrigger aggroTrigger = Caster.gameObject.GetComponent<AggroTrigger>();
            if (aggroTrigger != null)
                aggroTrigger.RaiseGlobalAggro(Spell.GlobalAggro);
        }
    }
}
