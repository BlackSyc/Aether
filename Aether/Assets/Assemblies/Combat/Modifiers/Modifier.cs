using Aether.Core.Combat.ScriptableObjects;
using System.Collections;
using UnityEngine;

namespace Aether.Combat.Modifiers
{
    internal class Modifier : IModifier
    {
        public ModifierType ModifierType { get; private set; }

        public float FallOffTime { get; set; }

        public Coroutine Coroutine { get; set; }

        public Modifier(ModifierType modifierType)
        {
            ModifierType = modifierType;
        }

        public IEnumerator ModifierCoroutine(ICombatSystem combatSystem)
        {
            FallOffTime = Time.time + ModifierType.Duration;
            return ModifierType.modifierCoroutine(combatSystem);
        }

        public void Abort(ICombatSystem combatSystem)
        {
            ModifierType.Abort(combatSystem);
        }
    }
}