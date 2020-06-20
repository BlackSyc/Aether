using Aether.Core.Combat;
using UnityEngine;

namespace Aether.ScriptableObjects.Spells.Behaviours
{
    public class BasicHeal : SpellBehaviour
    {
        [SerializeField]
        private Light castingLight;

        private ISpellCast spellCast;



        protected override void CastCompleted(ISpellCast spellCast)
        {
            if (spellCast.Target.HasCombatTarget(out ICombatSystem combatTarget))
            {
                if (combatTarget.Has(out IHealth health))
                    health.ChangeHealth(spellCast.Spell.HealthDelta);
            }

            castingLight.color = Color.white;
            Destroy(gameObject, 0.1f);
        }

        protected override void CastProgress(float progress)
        {
            castingLight.intensity = progress * 100;
        }

        protected override void CastStarted(ISpellCast spellCast)
        {
            castingLight.intensity = 0;
        }
    }
}
