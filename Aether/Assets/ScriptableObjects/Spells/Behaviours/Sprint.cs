using Aether.Combat.SpellSystem.SpellBehaviours;
using Aether.Core.Combat;
using Aether.ScriptableObjects.Modifiers;
using UnityEngine;

namespace Aether.ScriptableObjects.Spells
{
    internal class Sprint : SpellBehaviour
    {
        [SerializeField]
        private ModifierType modifier;

        public override void CastCanceled()
        {
        }

        public override void CastFired()
        {
            if (Target.HasCombatTarget(out ICombatSystem combatTarget))
            {
                if (combatTarget.Has(out IModifierSlots modifierSlots))
                    modifierSlots.AddModifier(modifier);
            }
            Destroy(gameObject);
        }

        public override void CastInterrupted()
        {
        }

        public override void CastStarted()
        {
        }
    }
}
