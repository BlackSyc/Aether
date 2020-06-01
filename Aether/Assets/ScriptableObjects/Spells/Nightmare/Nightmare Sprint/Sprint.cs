using Aether.Core.Combat;
using Aether.ScriptableObjects.Modifiers;
using UnityEngine;

namespace Aether.ScriptableObjects.Spells
{
    internal class Sprint : SpellObject
    {
        [SerializeField]
        private ModifierType modifier;

        public override void CastCanceled()
        {
        }

        public override void CastFired()
        {
            if (Target.Has(out IModifierSlots modifierSlots))
                modifierSlots.AddModifier(new Modifier(modifier));
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
