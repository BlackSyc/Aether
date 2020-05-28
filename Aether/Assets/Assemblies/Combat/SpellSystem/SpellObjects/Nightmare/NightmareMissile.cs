using Aether.Combat;
using Aether.Combat.AggroSystem;
using Aether.Combat.Health;
using Aether.Combat.Impact;

namespace Aether.Combat.SpellSystem
{
    internal class NightmareMissile : ArcaneMissile
    {

        public override void OnTargetHit(ICombatSystem target)
        {
            ExecuteTargetHitBehaviour(target);

            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        private void ExecuteTargetHitBehaviour(ICombatSystem target)
        {
            if (target.Has(out IHealth health))
                health.Damage(Spell.Damage);

            if (target.Has(out IAggroManager aggroManager))
                aggroManager.IncreaseAggro(Caster.CombatSystem, Spell.LocalAggro);

            if (target.Has(out IImpactHandler impactHandler))
                impactHandler.HandleImpactAtPosition(transform.forward * Spell.Damage * 25, Target.Transform.Position + targetOffset);
        }
    }
}
