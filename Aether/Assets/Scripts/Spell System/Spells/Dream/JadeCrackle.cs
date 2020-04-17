using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aether.Spells
{
    public class JadeCrackle : ArcaneMissile
    {
        [SerializeField]
        private float bounceDelay = 0.5f;

        [SerializeField]
        private GameObject trailRenderer;

        public override void CastFired(Target target, bool onSelf)
        {
            base.CastFired(target, onSelf);
            trailRenderer.SetActive(true);
        }

        public override void FixedUpdate()
        {
            if (travelling)
            {
                if (despawnTime < Time.time)
                    Destroy(this.gameObject);

                if (Hit())
                {
                    travelling = false;
                    GameObject hitFlash = Instantiate(hitPrefab, transform);
                    hitFlash.transform.SetParent(null, true);
                    Destroy(hitFlash, hitFlash.GetComponent<ParticleSystem>().main.duration);
                    Destroy(gameObject, .5f);
                    return;
                }



                transform.Translate(new Vector3(0, 0, movementSpeed * Time.fixedDeltaTime), Space.Self);

                Quaternion desiredRotation = Quaternion.LookRotation(Target.Position - transform.position, transform.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.fixedDeltaTime);
            }
        }


        private IEnumerator Travel(Target target)
        {
            Transform targetTransform = target.TargetTransform;

            if (CastOnSelf)
                targetTransform = Caster.gameObject.transform;


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
                .Where(x => x.Contains(Caster.gameObject.GetComponent<AggroTrigger>()))
                .Where(x => x.GetComponent<Health>())
                .OrderBy(x => Vector3.Distance(friendlyTarget.position, x.transform.position))
                .Select(x => x.GetComponent<Health>())
                .FirstOrDefault();
        }
    }
}
