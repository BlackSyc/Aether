using Aether.Core.Combat;
using Aether.Core.Movement;
using System;
using System.Collections;
using UnityEngine;

namespace Aether.ScriptableObjects.Modifiers
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Modifiers/Sprint")]
    [Serializable]
    public class SprintType : ModifierType
    {
        public float MovementSpeedIncrease;

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
            if (combatSystem.Has(out IMovementSystem movementSystem))
                movementSystem.MovementSpeed += MovementSpeedIncrease;
        }

        private void RemoveMovementSpeed(ICombatSystem combatSystem)
        {
            if (combatSystem.Has(out IMovementSystem movementSystem))
                movementSystem.MovementSpeed -= MovementSpeedIncrease;
        }
    }
}
