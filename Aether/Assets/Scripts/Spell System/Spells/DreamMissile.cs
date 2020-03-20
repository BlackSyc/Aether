using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamMissile : ArcaneMissile
{
    protected override bool Hit()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, .5f, Spell.layerMask);
        if (colliders.Length > 0)
        {
            // Add healing and spawning logic

            GetComponent<Animator>().SetTrigger("CastHit");
            return true;
        }
        return false;
    }
}
