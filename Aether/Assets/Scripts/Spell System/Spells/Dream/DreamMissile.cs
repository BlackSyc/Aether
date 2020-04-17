using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Aether.Spells
{
    public class DreamMissile : ArcaneMissile
    {
        public override bool ObjectHit(GameObject hitObject)
        {
            Health targetHealth = hitObject.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.Heal(Spell.Heal);
            }

            GetComponent<Animator>().SetTrigger("CastHit");
            return true;
        }
    }
}
