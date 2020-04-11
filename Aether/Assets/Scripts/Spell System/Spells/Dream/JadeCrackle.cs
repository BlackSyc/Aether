using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JadeCrackle : SpellObject
{
    [SerializeField]
    private float bounceDelay = 0.5f;

    public override void CastCanceled()
    {
        Destroy(this.gameObject);
    }

    public override void CastInterrupted()
    {
        Destroy(this.gameObject);
    }

    public override void CastStarted()
    {
        GetComponent<Animator>().SetFloat("CastTime", 1 / Spell.CastDuration);
        GetComponent<Animator>().SetTrigger("CastStarted");
    }

    public override void CastFired(Target target, bool onSelf)
    {
        base.CastFired(target, onSelf);

        GetComponent<Animator>().SetTrigger("CastFired");

        StartCoroutine(Travel(target));
    }

    private IEnumerator Travel(Target target)
    {
        Transform targetTransform = target.TargetTransform;

        if (CastOnSelf)
            targetTransform = Caster.transform;


        // Heal target if any
        if (!targetTransform)
        {
            Destroy(gameObject);
            yield break;
        }

        Health health = targetTransform.GetComponent<Health>();
        if (health)
        {
            float maximumHeal = health.MaxHealth - health.CurrentHealth;
            float leftOverHeal = maximumHeal < Spell.Heal ? Spell.Heal - maximumHeal : 0;

            health.Heal(Spell.Heal - leftOverHeal);

            if (leftOverHeal > 0)
            {
                yield return new WaitForSeconds(bounceDelay);
                Health closestEnemyHealth = FindEnemeyNearestTo(targetTransform);
                if (closestEnemyHealth)
                    closestEnemyHealth.Damage(leftOverHeal);
            }
            Destroy(gameObject);
        }


    }

    private Health FindEnemeyNearestTo(Transform friendlyTarget)
    {
        return FindObjectsOfType<AggroTable>()
            .Where(x => x.Contains(Caster.GetComponent<AggroTrigger>()))
            .Where(x => x.GetComponent<Health>())
            .OrderBy(x => Vector3.Distance(friendlyTarget.position, x.transform.position))
            .Select(x => x.GetComponent<Health>())
            .FirstOrDefault();

    }
}
