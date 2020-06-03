using Aether.Combat.SpellSystem.SpellBehaviours;
using Aether.Core.Combat;
using Aether.ScriptableObjects.Modifiers;
using System.Collections;
using UnityEngine;

namespace Aether.ScriptableObjects.Spells
{
    internal class NightmareBlast : SpellBehaviour
    {
        [SerializeField]
        private GameObject muzzleFlashPrefab;

        [SerializeField]
        private GameObject hitFlashPrefab;

        [SerializeField]
        private ModifierType modifierToApply;

        public override void CastCanceled()
        {
            //throw new System.NotImplementedException();
        }

        public override void CastFired()
        {
            StartCoroutine(Fire());
        }

        private IEnumerator Fire()
        {
            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, Caster.Get<ISpellSystem>().CastOrigin);
            Destroy(muzzleFlash, muzzleFlash.GetComponent<ParticleSystem>().main.duration);

            yield return new WaitForSeconds(0.1f);


            var hitFlash = Instantiate(hitFlashPrefab, null);


            if (Caster.Has(out ITargetSystem targetSystem))
                hitFlash.transform.position = targetSystem.GetCurrentTargetExact(Spell.LayerMask);
            else
                hitFlash.transform.position = Target.Transform.Position;




            hitFlash.transform.LookAt(Caster.Get<ISpellSystem>().CastOrigin);
            Destroy(hitFlash, hitFlash.GetComponent<ParticleSystem>().main.duration);

            if (Target.Has(out IModifierSlots modifierSlots))
                modifierSlots.AddModifier(modifierToApply);

            if (Target.Has(out IHealth health))
                health.ChangeHealth(Spell.HealthDelta);

            if (Target.Has(out IImpactHandler impactHandler))
                impactHandler.HandleImpactAtPosition(transform.forward * 3000, hitFlash.transform.position);

            Destroy(gameObject);
        }

        public override void CastInterrupted()
        {
            //throw new System.NotImplementedException();
        }

        public override void CastStarted()
        {
            //throw new System.NotImplementedException();
        }
    }
}
