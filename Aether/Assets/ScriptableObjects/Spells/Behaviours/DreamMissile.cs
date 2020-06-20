using Aether.Core.Combat;

namespace Aether.ScriptableObjects.Spells.Behaviours
{
    internal class DreamMissile : ArcaneMissile
    {
        protected override void ExecuteTargetHitBehaviour(ICombatSystem target)
        {
            if (target.Has<IHealth>(out var targetHealth))
                targetHealth.ChangeHealth(spellCast.Spell.HealthDelta);
        }
    }
}
