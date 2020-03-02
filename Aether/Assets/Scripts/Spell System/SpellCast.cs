using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CastEvent
{
    CastStarted, CastProgress, CastComplete, CastCancelled, CastInterrupted 
}
public class SpellCast
{
    public UnityEvent<CastEvent, SpellCast> CastEvents;

    private Transform caster;

    private GameObject spellObject;

    public Spell spell { get; private set; }

    private float endCast;

    private float beginCast;

    private bool castCancelled = false;

    public SpellCast(Spell spell, Transform caster)
    {
        this.spell = spell;
        this.caster = caster;
    }

    public IEnumerator Start()
    {
        this.beginCast = Time.time;
        this.endCast = this.beginCast + this.spell.castDuration;
        this.spellObject = GameObject.Instantiate(this.spell.SpellObject.gameObject, caster);

        this.spellObject.GetComponent<SpellObject>().CastStarted();
        CastEvents?.Invoke(CastEvent.CastStarted, this);

        while(Time.time < endCast)
        {
            if (castCancelled)
                yield break;

            CastEvents?.Invoke(CastEvent.CastProgress, this);
            yield return null;
        }

        this.spellObject.GetComponent<SpellObject>().CastFired();
        CastEvents?.Invoke(CastEvent.CastComplete, this);
    }

    public void Cancel()
    {
        this.spellObject.GetComponent<SpellObject>().CastCanceled();
        castCancelled = true;
    }

    public void Interrupt()
    {
        this.spellObject.GetComponent<SpellObject>().CastInterrupted();
        CastEvents?.Invoke(CastEvent.CastInterrupted, this);
        Cancel();
    }


}
