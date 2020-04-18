using UnityEngine;

namespace Aether.SpellSystem
{
    public class IllusionMissile : ArcaneMissile
    {

        public override bool ObjectHit(GameObject hitObject)
        {

            AggroManager enemyAggroManager = hitObject.GetComponent<AggroManager>();
            AggroTrigger casterAggroTrigger = Caster.gameObject.GetComponent<AggroTrigger>();

            if (enemyAggroManager != null && casterAggroTrigger)
            {
                enemyAggroManager.IncreaseAggro(casterAggroTrigger, Spell.LocalAggro);
            }
            // add knockback logic
            GetComponent<Animator>().SetTrigger("CastHit");
            return true;
        }
    }
}
