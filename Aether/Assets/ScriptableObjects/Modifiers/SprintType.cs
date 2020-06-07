using Aether.Core.Combat;
using System;
using System.Collections;
using UnityEngine;

namespace Aether.ScriptableObjects.Modifiers
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Modifiers/Sprint")]
    [Serializable]
    public class SprintType : ModifierType
    {
        public float SpeedIncrease;

        public override IEnumerator modifierCoroutine(ICombatSystem combatSystem)
        {
            AddMovementSpeed(combatSystem);

            yield break;
        }

        public override void Abort(ICombatSystem combatSystem)
        {
            RemoveMovementSpeed(combatSystem);
        }

        private void AddMovementSpeed(ICombatSystem combatSystem)
        {
            if (combatSystem.Has(out Attributes attributes))
                attributes.Speed += SpeedIncrease;
        }

        private void RemoveMovementSpeed(ICombatSystem combatSystem)
        {
            if (combatSystem.Has(out Attributes attributes))
                attributes.Speed -= SpeedIncrease;
        }
    }
}
