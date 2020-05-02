using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Aether.SpellSystem
{
    public class DreamMissile : ArcaneMissile
    {
        public override void OnTargetHit(GameObject targetObject)
        {
            ExecuteTargetHitBehaviour(targetObject);

            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        private void ExecuteTargetHitBehaviour(GameObject targetObject)
        {
            Health targetHealth = targetObject.GetComponent<Health>();
            if (targetHealth == null)
                return;

            targetHealth.Heal(Spell.Heal);
        }
    }
}
