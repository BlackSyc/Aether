using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DreamMissile : ArcaneMissile
{
    protected override bool Hit()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, .5f, Spell.layerMask | Player.Instance.TargetManager.ObstructionLayer);

        foreach (Collider collider in colliders)
        {
            if(Target.TargetTransform == collider.transform)
            {
                if (collider.GetComponent<Health>() != null)
                {
                    collider.GetComponent<Health>().ChangeHealth(Spell.HealthDelta);
                }

                GetComponent<Animator>().SetTrigger("CastHit");
                return true;
            }
            else if (Player.Instance.TargetManager.ObstructionLayer.Contains(collider.gameObject))
            {
                Debug.Log("Hit obstruction!");
                GetComponent<Animator>().SetTrigger("CastHit");
                return true;
            }
        }
        return false;
    }
}
