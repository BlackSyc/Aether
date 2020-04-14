using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneMissile : SpellObject
{
    [SerializeField]
    private GameObject muzzleFlashPrefab;

    [SerializeField]
    protected GameObject hitPrefab;

    [SerializeField]
    private float lifeTime = 10;

    private bool travelling = false;
    private float despawnTime;

    [SerializeField]
    private float movementSpeed = 20;

    [SerializeField]
    private float rotationSpeed = 500;

    private Quaternion initialRotation;

    public Target Target;

    public override void CastCanceled()
    {
        Destroy(this.gameObject);
    }

    public override void CastStarted()
    {
        GetComponent<Animator>().SetFloat("CastTime", 1/Spell.CastDuration);
        GetComponent<Animator>().SetTrigger("CastStarted");
    }

    public override void CastFired(Target target, bool onSelf)
    {
        base.CastFired(target, onSelf);

        Target = target;
        GetComponent<Animator>().SetTrigger("CastFired");
        transform.SetParent(null, true);
        initialRotation = transform.rotation;
        travelling = true;
        despawnTime = Time.time + lifeTime;

        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, transform);
        muzzleFlash.transform.SetParent(null, true);
        Destroy(muzzleFlash, muzzleFlash.GetComponent<ParticleSystem>().main.duration);
    }

    public override void CastInterrupted()
    {
        Debug.Log("Missile Interrupted!");
        Destroy(this.gameObject);
    }

    protected virtual bool Hit()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, .5f, Spell.layerMask | Layers.ObstructionLayer);
        foreach(Collider collider in colliders)
        {
            if(Target.TargetTransform == collider.transform)
            {
                return TargetHit(collider);
            }
            else if (Layers.ObstructionLayer.Contains(collider.gameObject))
            {
                return ObstructionHit(collider);
            }
        }
        return false;
    }

    private bool TargetHit(Collider collider)
    {
        Puzzle1_MissileTarget missileTarget = collider.GetComponent<Puzzle1_MissileTarget>();
        if (missileTarget != null)
        {
            missileTarget.Hit();
        }

        GetComponent<Animator>().SetTrigger("CastHit");
        return true;
    }

    private bool ObstructionHit(Collider collider)
    {
        GetComponent<Animator>().SetTrigger("CastHit");
        return true;
    }

    private void FixedUpdate()
    {
        if (travelling)
        {
            if(despawnTime < Time.time)
                Destroy(this.gameObject);

            if (Hit())
            {
                travelling = false;
                Destroy(this.gameObject, 1);
                return;
            }

            

            transform.Translate(new Vector3(0, 0, movementSpeed * Time.fixedDeltaTime), Space.Self);

            Quaternion desiredRotation = Quaternion.LookRotation(Target.Position - transform.position, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }


}
