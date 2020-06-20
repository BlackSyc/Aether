using Aether.Core.Combat;
using System;
using System.Collections;
using UnityEngine;

namespace Aether.ScriptableObjects.Modifiers
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Modifiers/Sprint")]
    [Serializable]
    public class SprintType : ModifierBase
    {
        public float SpeedIncrease;

        public override IEnumerator ModifierCoroutine(ICombatSystem combatSystem)
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

        public override void Initialize(ISpellCast spellCast)
        {
            throw new NotImplementedException();
        }
    }
}
