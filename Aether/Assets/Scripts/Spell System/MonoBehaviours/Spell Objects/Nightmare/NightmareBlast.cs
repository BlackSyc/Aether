using Aether.SpellSystem;
using Aether.TargetSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NightmareBlast : SpellObject
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
        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, Caster.CastOrigin);
        Destroy(muzzleFlash, muzzleFlash.GetComponent<ParticleSystem>().main.duration);

        yield return new WaitForSeconds(0.1f);


        var hitFlash = Instantiate(hitFlashPrefab, null);


        if (Caster.CombatSystem.Has(out ITargetSystem targetSystem))
            hitFlash.transform.position = targetSystem.GetCurrentTargetExact(Spell.LayerMask);
        else
            hitFlash.transform.position = Target.Transform.Position;




        hitFlash.transform.LookAt(Caster.CastOrigin);
        Destroy(hitFlash, hitFlash.GetComponent<ParticleSystem>().main.duration);

        if (Target.Has(out IModifierSlots modifierSlots))
            modifierSlots.AddModifier(new Modifier(modifierToApply));

        if (Target.Has(out IHealth health))
            health.Damage(Spell.Damage);

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
