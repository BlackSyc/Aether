using Aether.Combat;
using Aether.Combat.Modifiers;
using System;
using System.Collections;
using UnityEngine;

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

    public override void Stop(ICombatSystem combatSystem)
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
