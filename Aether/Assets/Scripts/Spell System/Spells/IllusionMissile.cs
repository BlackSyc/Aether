using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionMissile : ArcaneMissile
{
    protected override bool Hit()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, .5f, Spell.layerMask | Layers.ObstructionLayer);

        foreach (Collider collider in colliders)
        {
            if (Target.TargetTransform == collider.transform)
            {
                return TargetHit(collider);
            }
            else if (Layers.ObstructionLayer.Contains(collider.gameObject))
            {
                return ObstructionHit(collider);
            }
        }
        return false;
    }

    private bool TargetHit(Collider collider)
    {
        // add knockback logic
        GetComponent<Animator>().SetTrigger("CastHit");
        return true;
    }

    private bool ObstructionHit(Collider collider)
    {
        GetComponent<Animator>().SetTrigger("CastHit");
        return true;
    }
}
