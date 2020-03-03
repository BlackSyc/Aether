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

    public override void CastCanceled()
    {
        Destroy(this.gameObject);
    }

    public override void CastStarted()
    {
        GetComponent<Animator>().SetFloat("CastTime", 1/Spell.castDuration);
        GetComponent<Animator>().SetTrigger("CastStarted");
    }

    public override void CastFired()
    {
        GetComponent<Animator>().SetTrigger("CastFired");
        transform.SetParent(null, true);
        travelling = true;
        despawnTime = Time.time + lifeTime;
    }

    public override void CastInterrupted()
    {
        Debug.Log("Arcane Missile Interrupted!");
    }

    private void FixedUpdate()
    {
        if (travelling)
        {
            if(despawnTime < Time.time)
                Destroy(this.gameObject);

            transform.Translate(new Vector3(0, 0, movementSpeed * Time.fixedDeltaTime), Space.Self);
        }
    }
}
