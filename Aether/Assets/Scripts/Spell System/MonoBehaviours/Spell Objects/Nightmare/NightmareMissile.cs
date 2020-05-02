using UnityEngine;

namespace Aether.SpellSystem
{
    public class NightmareMissile : ArcaneMissile
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
            if (targetHealth)
            {
                targetHealth.Damage(Spell.Damage);
            }


            if (Caster == null)
                return;

            AggroManager enemyAggroManager = targetObject.GetComponent<AggroManager>();
            AggroTrigger casterAggroTrigger = Caster.gameObject.GetComponent<AggroTrigger>();

            if (enemyAggroManager == null || !casterAggroTrigger)
                return;

            enemyAggroManager.IncreaseAggro(casterAggroTrigger, Spell.LocalAggro);
        }
    }
}
