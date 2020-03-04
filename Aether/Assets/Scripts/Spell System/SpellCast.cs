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
            return castTime / Spell.CastDuration;
        } }

    public Transform CastParent { get; private set; }

    private GameObject spellObject;

    public Spell Spell { get; private set; }

    private TargetManager targetManager;

    private float beginCast;

    private float castTime = 0;

    private bool castCancelled = false;



    public SpellCast(Spell spell, Transform castParent, TargetManager targetManager)
    {
        Spell = spell;
        CastParent = castParent;
        this.targetManager = targetManager;
    }

    public IEnumerator Start()
    {
        beginCast = Time.time;
        castTime = Time.time - beginCast;
        spellObject = GameObject.Instantiate(Spell.SpellObject.gameObject, CastParent);

        spellObject.GetComponent<SpellObject>().Spell = Spell;
        spellObject.GetComponent<SpellObject>().CastStarted();
        CastStarted?.Invoke(this);

        Target initialTarget = targetManager.GetCurrentTarget();
        if (initialTarget.HasTargetTransform)
            targetManager.LockTarget(initialTarget);

        while(castTime < Spell.CastDuration)
        {
            castTime = Time.time - beginCast;
            if (castCancelled)
            {
                targetManager.UnlockTarget();
                yield break;
            }

            CastProgress?.Invoke(this);
            yield return null;
        }

        spellObject.GetComponent<SpellObject>().CastFired(targetManager.GetCurrentTarget());
        targetManager.UnlockTarget();
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
