using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EventType
{
    CastStarted, CastProgress, CastComplete, CastCancelled, CastInterrupted 
}

[Serializable]
public class CastEvent : UnityEvent<EventType, SpellCast> { }

public class SpellCast
{
    public CastEvent CastEvents;

    public float CastProgress { get
        {
            return castTime / spell.castDuration;
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
        CastEvents = new CastEvent();
    }

    public IEnumerator Start()
    {
        beginCast = Time.time;
        castTime = Time.time - beginCast;
        spellObject = GameObject.Instantiate(spell.SpellObject.gameObject, castParent);

        spellObject.GetComponent<SpellObject>().Spell = spell;
        spellObject.GetComponent<SpellObject>().CastStarted();
        CastEvents?.Invoke(EventType.CastStarted, this);

        while(castTime < spell.castDuration)
        {
            castTime = Time.time - beginCast;
            if (castCancelled)
                yield break;

            CastEvents?.Invoke(EventType.CastProgress, this);
            yield return null;
        }

        spellObject.GetComponent<SpellObject>().CastFired();
        CastEvents?.Invoke(EventType.CastComplete, this);
    }

    public void Cancel()
    {
        spellObject.GetComponent<SpellObject>().CastCanceled();
        CastEvents?.Invoke(EventType.CastCancelled, this);
        castCancelled = true;
    }

    public void Interrupt()
    {
        spellObject.GetComponent<SpellObject>().CastInterrupted();
        CastEvents?.Invoke(EventType.CastInterrupted, this);
        Cancel();
    }


}
