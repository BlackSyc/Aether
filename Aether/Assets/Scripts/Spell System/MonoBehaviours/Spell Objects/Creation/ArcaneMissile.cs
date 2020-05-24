using Aether.Combat;
using Aether.Combat.SpellSystem.SpellObjects;
using Aether.Combat.TargetSystem;
using UnityEngine;

namespace Aether.SpellSystem
{
    public class ArcaneMissile : Projectile
    {
        [SerializeField]
        private GameObject muzzleFlashPrefab;

        [SerializeField]
        protected GameObject hitFlashPrefab;

        public override void CastCanceled()
        {
            Destroy(this.gameObject);
        }

        public override void CastStarted()
        {
            GetComponent<Animator>().SetFloat("CastTime", 1 / Spell.CastDuration);
            GetComponent<Animator>().SetTrigger("CastStarted");
        }

        public override void CastFired()
        {
            base.CastFired();

            PlayMissileFiredAnimation();
        }

        public override void CastInterrupted()
        {
            Debug.Log("Missile Interrupted!");
            Destroy(this.gameObject);
        }

        public override void OnObstructionHit(GameObject obstructionObject)
        {
            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        public override void OnTargetHit(ICombatSystem target)
        {
            ExecuteTargetHitBehaviour(target);

            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        private void ExecuteTargetHitBehaviour(ICombatSystem target)
        {
            if(target.Has(out Puzzle1_MissileTarget missileTarget))
            {
                missileTarget.Hit();
            }
        }

        public void PlayMissileHitAnimation()
        {
            Vector3 hitPosition = transform.position;

            if(Caster.CombatSystem.Has(out ITargetSystem targetSystem))
                hitPosition = targetSystem.GetCurrentTargetExact(Spell.LayerMask);

            GameObject hitFlash = Instantiate(hitFlashPrefab, transform);
            hitFlash.transform.SetParent(null, true);
            Destroy(hitFlash, hitFlash.GetComponent<ParticleSystem>().main.duration);
        }

        public void PlayMissileFiredAnimation()
        {
            GetComponent<Animator>().SetTrigger("CastFired");

            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, Caster.CastOrigin);
            Destroy(muzzleFlash, muzzleFlash.GetComponent<ParticleSystem>().main.duration);
        }
    }
}
