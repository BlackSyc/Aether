using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareMissile : ArcaneMissile
{

    public override bool ObjectHit(GameObject hitObject)
    {
        Health targetHealth = hitObject.GetComponent<Health>();
        if (targetHealth)
        {
            targetHealth.Damage(Spell.Damage);
        }

        AggroManager enemyAggroManager = hitObject.GetComponent<AggroManager>();
        if(Caster != null)
        {
            AggroTrigger casterAggroTrigger = Caster.GetComponent<AggroTrigger>();

            if (enemyAggroManager != null && casterAggroTrigger)
            {
                enemyAggroManager.IncreaseAggro(casterAggroTrigger, Spell.LocalAggro);
            }
        }

        GetComponent<Animator>().SetTrigger("CastHit");
        return true;
    }
}
