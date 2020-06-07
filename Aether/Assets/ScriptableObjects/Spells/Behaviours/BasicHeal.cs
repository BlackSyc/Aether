using Aether.Combat.Health;
using UnityEngine;

namespace Aether.Combat.SpellSystem.SpellBehaviours
{
    public class BasicHeal : SpellBehaviour
    {

        [SerializeField]
        private Light castingLight;

        private bool castFired = false;

        public override void CastCanceled()
        {
        }

        public override void CastFired()
        {
            if (Target.HasCombatTarget(out Core.Combat.ICombatSystem combatTarget))
            {
                if (combatTarget.Has(out IHealth health))
                    health.ChangeHealth(Spell.HealthDelta);
            }

            castFired = true;
            castingLight.color = Color.white;
            Destroy(gameObject, 0.1f);
        }

        public override void CastInterrupted()
        {
        }

        public override void CastStarted()
        {
        }

        private void Update()
        {
            if (!castFired)
                castingLight.intensity += (castingLight.intensity * Time.deltaTime);
        }
    }
}
