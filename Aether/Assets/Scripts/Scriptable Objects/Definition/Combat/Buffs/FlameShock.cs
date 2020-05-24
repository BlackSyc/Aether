using Aether.TargetSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Modifiers/FlameShock")]
[Serializable]
public class FlameShock : ModifierType
{
    [SerializeField]
    private float damageTickAmount;

    [SerializeField]
    private float tickDelay;

    public override IEnumerator modifierCoroutine(ICombatSystem combatSystem)
    {
        while (true)
        {
            if (combatSystem.Has(out IHealth health))
            {
                health.Damage(damageTickAmount);
            }
            yield return new WaitForSeconds(tickDelay);
        }
    }
}
