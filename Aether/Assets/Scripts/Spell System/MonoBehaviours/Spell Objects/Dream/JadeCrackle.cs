using Aether.TargetSystem;
using ICSharpCode.NRefactory.Ast;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Aether.SpellSystem
{
    public class JadeCrackle : SpellObject
    {
        [SerializeField]
        private float bounceDelay = 0.5f;

        [SerializeField]
        private GameObject trailRenderer;

        public override void CastFired()
        {
            trailRenderer.SetActive(true);
        }

        //public override void FixedUpdate()
        //{
        //    if (travelling)
        //    {
        //        if (despawnTime < Time.time)
        //            Destroy(this.gameObject);

        //        if (Hit())
        //        {
        //            travelling = false;
        //            GameObject hitFlash = Instantiate(hitFlashPrefab, transform);
        //            hitFlash.transform.SetParent(null, true);
        //            Destroy(hitFlash, hitFlash.GetComponent<ParticleSystem>().main.duration);
        //            Destroy(gameObject, .5f);
        //            return;
        //        }



        //        transform.Translate(new Vector3(0, 0, movementSpeed * Time.fixedDeltaTime), Space.Self);

        //        Quaternion desiredRotation = Quaternion.LookRotation(Target.Position - transform.position, transform.up);
        //        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.fixedDeltaTime);
        //    }
        //}


        private IEnumerator Travel(ICombatComponent target)
        {
            if (target == null)
            {
                Destroy(gameObject);
                yield break;
            }

            if (target.Has(out IHealth health))
            {
                float maximumHeal = health.MaxHealth - health.CurrentHealth;
                float leftOverHeal = maximumHeal < Spell.Heal ? Spell.Heal - maximumHeal : 0;

                health.Heal(Spell.Heal - leftOverHeal);

                if (leftOverHeal > 0)
                {
                    yield return new WaitForSeconds(bounceDelay);
                    Health closestEnemyHealth = FindEnemeyNearestTo(target.Get<Transform>());
                    if (closestEnemyHealth)
                        closestEnemyHealth.Damage(leftOverHeal);
                }
                Destroy(gameObject);
            }


        }

        private Health FindEnemeyNearestTo(Transform friendlyTarget)
        {
            return FindObjectsOfType<AggroTable>()
                .Where(x => x.Contains(Caster.CombatComponent))
                .Where(x => x.GetComponent<Health>())
                .OrderBy(x => Vector3.Distance(friendlyTarget.position, x.transform.position))
                .Select(x => x.GetComponent<Health>())
                .FirstOrDefault();
        }

        public override void CastStarted()
        {
            //throw new System.NotImplementedException();
        }

        public override void CastInterrupted()
        {
            //throw new System.NotImplementedException();
        }

        public override void CastCanceled()
        {
            //throw new System.NotImplementedException();
        }
    }
}
