using Aether.TargetSystem;
using System.Linq;
using UnityEngine;

namespace Aether.SpellSystem
{
    public class IllusionMissile : ArcaneMissile
    {

        public override void OnTargetHit(ICombatComponent target)
        {
            ExecuteTargetHitBehaviour(target);

            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        private void ExecuteTargetHitBehaviour(ICombatComponent target)
        {
            target.Get<AggroManager>()?.IncreaseAggro(target, Spell.LocalAggro);
            

            // to do: add knockback logic
        }
    }
}
