using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneMissile : SpellObject
{

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

    public override void CastFired(Target target)
    {
        Target = target;
        GetComponent<Animator>().SetTrigger("CastFired");
        transform.SetParent(null, true);
        initialRotation = transform.rotation;
        travelling = true;
        despawnTime = Time.time + lifeTime;
    }

    public override void CastInterrupted()
    {
        Debug.Log("Missile Interrupted!");
    }

    protected virtual bool Hit()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, .5f, Spell.layerMask);
        if (colliders.Length > 0)
        {
            colliders[0].GetComponent<Puzzle1_MissileTarget>()?.Hit();

            GetComponent<Animator>().SetTrigger("CastHit");
            return true;
        }
        return false;
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
