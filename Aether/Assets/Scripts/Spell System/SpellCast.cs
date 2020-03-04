using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpellCast
{
    public delegate void CastEventHandler(SpellCast cast);
    public event CastEventHandler CastStarted;
    public event CastEventHandler CastProgress;
    public event CastEventHandler CastCancelled;
    public event CastEventHandler CastInterrupted;
    public event CastEventHandler CastComplete;

    
    public float Progress { get
        {
            return castTime / spell.CastDuration;
        } }

    private Transform castParent;

    private GameObject spellObject;

    public Spell spell { get; private set; }

    private float beginCast;

    private float castTime = 0;

    private bool castCancelled = false;



    public SpellCast(Spell spell, Transform castParent)
    {
        this.spell = spell;
        this.castParent = castParent;
    }

    public IEnumerator Start()
    {
        beginCast = Time.time;
        castTime = Time.time - beginCast;
        spellObject = GameObject.Instantiate(spell.SpellObject.gameObject, castParent);

        spellObject.GetComponent<SpellObject>().Spell = spell;
        spellObject.GetComponent<SpellObject>().CastStarted();
        CastStarted?.Invoke(this);

        while(castTime < spell.CastDuration)
        {
            castTime = Time.time - beginCast;
            if (castCancelled)
                yield break;

            CastProgress?.Invoke(this);
            yield return null;
        }

        spellObject.GetComponent<SpellObject>().CastFired();
        CastComplete?.Invoke(this);
    }

    public void Cancel()
    {
        spellObject.GetComponent<SpellObject>().CastCanceled();
        CastCancelled?.Invoke(this);
        castCancelled = true;
    }

    public void Interrupt()
    {
        spellObject.GetComponent<SpellObject>().CastInterrupted();
        CastInterrupted?.Invoke(this);
        Cancel();
    }


}
