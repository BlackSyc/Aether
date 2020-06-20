using Aether.Core.Combat;

namespace Aether.ScriptableObjects.Spells.Behaviours
{
    internal class IllusionMissile : ArcaneMissile
    {

        protected override void ExecuteTargetHitBehaviour(ICombatSystem target)
        {
            target.Get<IAggroManager>()?.IncreaseAggro(target, spellCast.Spell.LocalAggro);

            // to do: add knockback logic
        }
    }
}
