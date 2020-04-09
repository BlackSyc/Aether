using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpellCast
{
    public event Action<SpellCast> CastStarted;
    public event Action<float> CastProgress;
    public event Action<SpellCast> CastCancelled;
    public event Action<SpellCast> CastInterrupted;
    public event Action<SpellCast> CastComplete;

    
    public float Progress { get
        {
            return castTime / Spell.CastDuration;
        } }

    public Transform CastParent { get; private set; }

    public GameObject Caster { get; private set; }

    private SpellObject spellObject;

    public Spell Spell { get; private set; }

    private TargetManager targetManager;

    private float beginCast;

    private float castTime = 0;

    private bool castCancelled = false;



    public SpellCast(Spell spell, Transform castParent, GameObject caster, TargetManager targetManager)
    {
        Spell = spell;
        CastParent = castParent;
        Caster = caster;
        this.targetManager = targetManager;
    }

    public IEnumerator Start()
    {
        beginCast = Time.time;
        castTime = Time.time - beginCast;
        spellObject = GameObject.Instantiate(Spell.SpellObject.gameObject, CastParent).GetComponent<SpellObject>();

        spellObject.Spell = Spell;
        spellObject.Caster = Caster;

        spellObject.CastStarted();
        CastStarted?.Invoke(this);

        if (targetManager.GetCurrentTarget().HasTargetTransform && Spell.layerMask.Contains(targetManager.GetCurrentTarget().TargetTransform.gameObject))
            targetManager.LockTarget();

        while(castTime < Spell.CastDuration)
        {
            if(!Spell.CastWhileMoving && Player.Instance.PlayerMovement.IsMoving)
            {
                Cancel();
            }

            castTime = Time.time - beginCast;
            if (castCancelled)
            {
                targetManager.UnlockTarget();
                yield break;
            }

            CastProgress?.Invoke(Progress);
            yield return null;
        }

        spellObject.CastFired(targetManager.Target);
        targetManager.UnlockTarget();
        CastComplete?.Invoke(this);
    }

    public void Cancel()
    {
        spellObject.CastCanceled();
        CastCancelled?.Invoke(this);
        castCancelled = true;
    }

    public void Interrupt()
    {
        spellObject.CastInterrupted();
        CastInterrupted?.Invoke(this);
        Cancel();
    }
}
