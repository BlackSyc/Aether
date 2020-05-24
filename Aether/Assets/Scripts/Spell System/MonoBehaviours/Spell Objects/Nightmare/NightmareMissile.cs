using Aether.TargetSystem;
using UnityEngine;

namespace Aether.SpellSystem
{
    public class NightmareMissile : ArcaneMissile
    {

        public override void OnTargetHit(ICombatComponent target)
        {
            ExecuteTargetHitBehaviour(target);

            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        private void ExecuteTargetHitBehaviour(ICombatComponent target)
        {
            if (target.Has(out IHealth health))
                health.Damage(Spell.Damage);

            if (target.Has(out AggroManager aggroManager))
                aggroManager.IncreaseAggro(Caster.CombatComponent, Spell.LocalAggro);

            if (target.Has(out IImpactHandler impactHandler))
                impactHandler.HandleImpactAtPosition(transform.forward * Spell.Damage * 25, Target.Transform.Position + targetOffset);
        }
    }
}
