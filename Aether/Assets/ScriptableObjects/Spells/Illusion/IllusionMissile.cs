using Aether.Core.Combat;

namespace Aether.ScriptableObjects.Spells
{
    internal class IllusionMissile : ArcaneMissile
    {

        public override void OnTargetHit(ICombatSystem target)
        {
            ExecuteTargetHitBehaviour(target);

            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        private void ExecuteTargetHitBehaviour(ICombatSystem target)
        {
            target.Get<IAggroManager>()?.IncreaseAggro(target, Spell.LocalAggro);
            

            // to do: add knockback logic
        }
    }
}
