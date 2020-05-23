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
        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, Caster.CastParent);
        Destroy(muzzleFlash, muzzleFlash.GetComponent<ParticleSystem>().main.duration);

        yield return new WaitForSeconds(0.1f);

        var allHits = Physics.RaycastAll(transform.position, Target.Transform.Position - transform.position, Spell.LayerMask);

        var hitPoint = allHits
            .Single(x => x.collider.GetComponent<ICombatComponent>() == Target)
            .point;


        var hitFlash = Instantiate(hitFlashPrefab, null);
        hitFlash.transform.position = hitPoint;
        hitFlash.transform.LookAt(Caster.CastParent);
        Destroy(hitFlash, hitFlash.GetComponent<ParticleSystem>().main.duration);

        if (Target.Has(out IHealth health))
            health.Damage(Spell.Damage);

        if (Target.Has(out IImpactHandler impactHandler))
            impactHandler.HandleImpact(transform.forward * 3000);
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
