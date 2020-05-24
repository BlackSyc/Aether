using Aether.TargetSystem;
using System;
using System.Collections;
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
                health.Damage(damageTickAmount);

            var rng = new UnityEngine.Random();

            if (combatSystem.Has(out IImpactHandler impactHandler))
                impactHandler.HandleImpact(new Vector3(UnityEngine.Random.Range(-1000, 1000), UnityEngine.Random.Range(800,1000), UnityEngine.Random.Range(-1000, 1000)));

            yield return new WaitForSeconds(tickDelay);
        }
    }
}
