using UnityEngine;

namespace Aether.SpellSystem
{
    public class IllusionMissile : ArcaneMissile
    {

        public override void OnTargetHit(GameObject targetObject)
        {
            ExecuteTargetHitBehaviour(targetObject);

            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        private void ExecuteTargetHitBehaviour(GameObject targetObject)
        {
            AggroManager enemyAggroManager = targetObject.GetComponent<AggroManager>();
            AggroTrigger casterAggroTrigger = Caster.gameObject.GetComponent<AggroTrigger>();

            if (enemyAggroManager == null || !casterAggroTrigger)
                return;

            
            enemyAggroManager.IncreaseAggro(casterAggroTrigger, Spell.LocalAggro);
            

            // to do: add knockback logic
        }
    }
}
