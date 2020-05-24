using System.Collections;
using UnityEngine;

namespace Aether.Combat.Modifiers
{
    public class Modifier
    {
        public ModifierType ModifierType { get; private set; }

        public float FallOffTime { get; set; }

        public Coroutine Coroutine;

        public Modifier(ModifierType modifierType)
        {
            ModifierType = modifierType;
        }

        public IEnumerator ModifierCoroutine(ICombatSystem combatSystem)
        {
            FallOffTime = Time.time + ModifierType.Duration;
            return ModifierType.modifierCoroutine(combatSystem);
        }

        public void Stop(ICombatSystem combatSystem)
        {
            ModifierType.Stop(combatSystem);
        }
    }
}