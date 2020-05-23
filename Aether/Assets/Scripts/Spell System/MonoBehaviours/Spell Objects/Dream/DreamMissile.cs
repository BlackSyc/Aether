using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Aether.TargetSystem;

namespace Aether.SpellSystem
{
    public class DreamMissile : ArcaneMissile
    {
        public override void OnTargetHit(ICombatComponent target)
        {
            ExecuteTargetHitBehaviour(target);

            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        private void ExecuteTargetHitBehaviour(ICombatComponent target)
        {
            if (target.Has<IHealth>(out var targetHealth))
                targetHealth.Heal(Spell.Heal);
        }
    }
}
