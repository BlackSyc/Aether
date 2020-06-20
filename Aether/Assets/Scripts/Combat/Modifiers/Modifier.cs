using Aether.Core.Combat;
using System.Collections;
using UnityEngine;

namespace Aether.Combat.Modifiers
{
    internal class Modifier : IModifierType
    {
        public Core.Combat.IModifierType ModifierType { get; private set; }

        public float FallOffTime { get; set; }

        public Coroutine Coroutine { get; set; }

        public Modifier(Core.Combat.IModifierType modifierType)
        {
            ModifierType = modifierType;
        }

        public IEnumerator ModifierCoroutine(Core.Combat.ICombatSystem combatSystem)
        {
            FallOffTime = Time.time + ModifierType.Duration;
            return ModifierType.ModifierCoroutine(combatSystem);
        }

        public void Abort(Core.Combat.ICombatSystem combatSystem)
        {
            ModifierType.Abort(combatSystem);
        }
    }
}