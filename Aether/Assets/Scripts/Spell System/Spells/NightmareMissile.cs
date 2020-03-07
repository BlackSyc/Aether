using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareMissile : ArcaneMissile
{
    protected override bool Hit()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, .5f, Spell.layerMask);
        if (colliders.Length > 0)
        {
            // Add damage and object removal logic

            GetComponent<Animator>().SetTrigger("CastHit");
            return true;
        }
        return false;
    }
}
