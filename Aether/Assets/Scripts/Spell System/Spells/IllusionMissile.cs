using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionMissile : ArcaneMissile
{

    public override bool ObjectHit(GameObject hitObject)
    {

        AggroManager enemyAggroManager = hitObject.GetComponent<AggroManager>();
        AggroTrigger casterAggroTrigger = Caster.GetComponent<AggroTrigger>();

        if (enemyAggroManager != null && casterAggroTrigger)
        {
            enemyAggroManager.IncreaseAggro(casterAggroTrigger, Spell.LocalAggro);
        }
        // add knockback logic
        GetComponent<Animator>().SetTrigger("CastHit");
        return true;
    }
}
