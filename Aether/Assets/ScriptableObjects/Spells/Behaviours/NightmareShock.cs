using Aether.Combat.SpellSystem.SpellBehaviours;
using Aether.Core.Combat;
using Aether.ScriptableObjects.Modifiers;
using System.Collections;
using UnityEngine;

namespace Aether.ScriptableObjects.Spells
{
    internal class NightmareShock : SpellBehaviour
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



            if (Target.HasCombatTarget(out Core.Combat.ICombatSystem combatTarget))
                hitFlash.transform.position = Target.RelativeHitPoint + combatTarget.Transform.Position;
            else
                hitFlash.transform.position = Target.RelativeHitPoint;


            hitFlash.transform.LookAt(Caster.Get<ISpellSystem>().CastOrigin);
            Destroy(hitFlash, hitFlash.GetComponent<ParticleSystem>().main.duration);

            if (combatTarget != null)
            {
                if (combatTarget.Has(out IModifierSlots modifierSlots))
                    modifierSlots.AddModifier(modifierToApply);
            }


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
