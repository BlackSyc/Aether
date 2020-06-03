using Aether.Core.Combat;

namespace Aether.ScriptableObjects.Spells
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
                health.ChangeHealth(Spell.HealthDelta);

            if (target.Has(out IAggroManager aggroManager))
                aggroManager.IncreaseAggro(Caster, Spell.LocalAggro);

            if (target.Has(out IImpactHandler impactHandler))
                impactHandler.HandleImpactAtPosition(transform.forward * Spell.HealthDelta * -25, Target.Transform.Position + targetOffset);
        }
    }
}
