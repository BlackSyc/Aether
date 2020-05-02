using Aether.TargetSystem;
using ScriptableObjects;
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

        public override void OnTargetHit(GameObject targetObject)
        {
            ExecuteTargetHitBehaviour(targetObject);

            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        private void ExecuteTargetHitBehaviour(GameObject targetObject)
        {
            Puzzle1_MissileTarget missileTarget = targetObject.GetComponent<Puzzle1_MissileTarget>();
            if (missileTarget == null)
                return;

            missileTarget.Hit();
        }

        public void PlayMissileHitAnimation()
        {
            GameObject hitFlash = Instantiate(hitFlashPrefab, transform);
            hitFlash.transform.SetParent(null, true);
            Destroy(hitFlash, hitFlash.GetComponent<ParticleSystem>().main.duration);
        }

        public void PlayMissileFiredAnimation()
        {
            GetComponent<Animator>().SetTrigger("CastFired");

            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, transform);
            muzzleFlash.transform.SetParent(null, true);
            Destroy(muzzleFlash, muzzleFlash.GetComponent<ParticleSystem>().main.duration);
        }
    }
}
