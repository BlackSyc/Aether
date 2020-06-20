using Aether.Core.Combat;

namespace Aether.ScriptableObjects.Spells.Behaviours
{
    internal class NightmareMissile : ArcaneMissile
    {
        protected override void ExecuteTargetHitBehaviour(ICombatSystem target)
        {
            if (target.Has(out IHealth health))
                health.ChangeHealth(spellCast.Spell.HealthDelta);

            if (target.Has(out IAggroManager aggroManager))
                aggroManager.IncreaseAggro(spellCast.Caster, spellCast.Spell.LocalAggro);

            if (target.Has(out IImpactHandler impactHandler))
                impactHandler.HandleImpactAtPosition(transform.forward * spellCast.Spell.HealthDelta * -25, spellCast.Target.RelativeHitPoint);
        }
    }
}
