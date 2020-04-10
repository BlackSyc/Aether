﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DreamMissile : ArcaneMissile
{
    protected override bool Hit()
    {
        if (CastOnSelf)
            return TargetHit(Caster);

        Collider[] colliders = Physics.OverlapSphere(transform.position, .5f, Spell.layerMask | Layers.ObstructionLayer);

        foreach (Collider collider in colliders)
        {
            if(Target.TargetTransform == collider.transform)
            {
                return TargetHit(collider.gameObject);
            }
            else if (Layers.ObstructionLayer.Contains(collider.gameObject))
            {
                return ObstructionHit(collider.gameObject);
            }
        }
        return false;
    }

    private bool TargetHit(GameObject gameObject)
    {
        Health targetHealth = gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.Heal(Spell.Heal);
        }

        GetComponent<Animator>().SetTrigger("CastHit");
        return true;
    }

    private bool ObstructionHit(GameObject gameObject)
    {
        GetComponent<Animator>().SetTrigger("CastHit");
        return true;
    }
}
