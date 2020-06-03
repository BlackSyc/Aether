using Aether.Core.Combat;

namespace Aether.ScriptableObjects.Spells
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
                targetHealth.ChangeHealth(Spell.HealthDelta);
        }
    }
}
