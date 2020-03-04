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
        Debug.Log("Arcane Missile Interrupted!");
    }

    private void Hit()
    {
        travelling = false;
        GetComponent<Animator>().SetTrigger("CastHit");
        Destroy(this.gameObject, 1);
    }

    private void FixedUpdate()
    {
        if (travelling)
        {
            if(despawnTime < Time.time)
                Destroy(this.gameObject);

            if(Physics.OverlapSphere(transform.position, .5f, Spell.layerMask).Length > 0)
            {
                Hit();
            }

            transform.Translate(new Vector3(0, 0, movementSpeed * Time.fixedDeltaTime), Space.Self);

            Quaternion desiredRotation = Quaternion.LookRotation(Target.Position - transform.position, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }


}
