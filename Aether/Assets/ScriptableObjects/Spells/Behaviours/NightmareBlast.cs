using Aether.Core.Combat;
using System.Collections;
using UnityEngine;

namespace Aether.ScriptableObjects.Spells.Behaviours
{
    internal class NightmareBlast : SpellBehaviour
    {
        [SerializeField]
        private GameObject muzzleFlashPrefab;

        [SerializeField]
        private GameObject hitFlashPrefab;

        private ISpellCast spellCast;

        protected override void CastCompleted(ISpellCast spellCast)
        {
            StartCoroutine(Fire(spellCast));
        }

        protected override void CastStarted(ISpellCast spellCast)
        {
            // to do: add casting effect
        }

        private IEnumerator Fire(ISpellCast spellCast)
        {
            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, spellCast.Caster.Get<ISpellSystem>().CastOrigin);
            Destroy(muzzleFlash, muzzleFlash.GetComponent<ParticleSystem>().main.duration);

            yield return new WaitForSeconds(0.1f);


            var hitFlash = Instantiate(hitFlashPrefab, null);

            if (spellCast.Target.HasCombatTarget(out ICombatSystem combatTarget))
                hitFlash.transform.position = spellCast.Target.RelativeHitPoint + combatTarget.Transform.Position;
            else
                hitFlash.transform.position = spellCast.Target.RelativeHitPoint;

            hitFlash.transform.LookAt(spellCast.Caster.Get<ISpellSystem>().CastOrigin);
            Destroy(hitFlash, hitFlash.GetComponent<ParticleSystem>().main.duration);

            if (combatTarget != null)
            {
                if (combatTarget.Has(out IHealth health))
                    health.ChangeHealth(spellCast.Spell.HealthDelta);

                if (combatTarget.Has(out IImpactHandler impactHandler))
                    impactHandler.HandleImpactAtPosition(transform.forward * 3000, hitFlash.transform.position);
            }
            Destroy(gameObject);
        }
    }
}
