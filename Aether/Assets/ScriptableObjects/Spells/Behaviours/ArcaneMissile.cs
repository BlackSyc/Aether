using Aether.Core.Combat;
using System;
using UnityEngine;

namespace Aether.ScriptableObjects.Spells.Behaviours
{
    [Serializable]
    internal class ArcaneMissile : ProjectileBehaviour
    {
        [SerializeField]
        private GameObject muzzleFlashPrefab;

        [SerializeField]
        protected GameObject hitFlashPrefab;

        #region Projectile
        public override void OnObstructionHit(GameObject obstructionObject)
        {
            GameObject hitFlash = Instantiate(hitFlashPrefab, transform);
            hitFlash.transform.SetParent(null, true);
            Destroy(hitFlash, hitFlash.GetComponent<ParticleSystem>().main.duration);

            Destroy(gameObject);
        }

        public override void OnTargetHit(ICombatSystem target)
        {
            ExecuteTargetHitBehaviour(target);

            GameObject hitFlash = Instantiate(hitFlashPrefab, transform);
            hitFlash.transform.SetParent(null, true);
            Destroy(hitFlash, hitFlash.GetComponent<ParticleSystem>().main.duration);

            Destroy(gameObject);
        }
        #endregion

        protected virtual void ExecuteTargetHitBehaviour(ICombatSystem target)
        {
            if (target.Has(out IMissileTarget missileTarget))
            {
                missileTarget.Hit();
            }
        }

        protected override void CastCompleted(ISpellCast spellCast)
        {
            base.CastCompleted(spellCast);

            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, spellCast.Caster.Get<ISpellSystem>().CastOrigin);
            Destroy(muzzleFlash, muzzleFlash.GetComponent<ParticleSystem>().main.duration);
        }
    }
}
