using Aether.Combat.Health;

namespace Aether.Combat.SpellSystem
{
    internal class DreamMissile : ArcaneMissile
    {
        public override void OnTargetHit(ICombatSystem target)
        {
            ExecuteTargetHitBehaviour(target);

            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        private void ExecuteTargetHitBehaviour(ICombatSystem target)
        {
            if (target.Has<IHealth>(out var targetHealth))
                targetHealth.Heal(Spell.Heal);
        }
    }
}
