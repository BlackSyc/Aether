using Aether.Spells.ScriptableObjects;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aether.Spells
{
    public class SpellObject : MonoBehaviour
    {
        public Spell Spell;

        public ISpellSystem Caster;

        public bool CastOnSelf = false;

        public virtual void CastStarted() { }

        public virtual void CastInterrupted() { }

        public virtual void CastCanceled() { }

        public virtual void CastFired(Target target, bool onSelf)
        {
            CastOnSelf = onSelf;
            AggroTrigger aggroTrigger = Caster.gameObject.GetComponent<AggroTrigger>();
            if (aggroTrigger != null)
                aggroTrigger.RaiseGlobalAggro(Spell.GlobalAggro);
        }
    }
}
