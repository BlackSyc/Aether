using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpellCast
{
    public struct Events
    {
        public static event Action<SpellCast> OnCastSpell;

        public static void CastSpell(SpellCast spellCast)
        {
            OnCastSpell?.Invoke(spellCast);
        }
    }

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
        Events.CastSpell(this);
        CastStarted?.Invoke(this);

        if (targetManager.GetCurrentTarget().HasTargetTransform)
            targetManager.LockTarget();

        while(castTime < Spell.CastDuration)
        {
            if(!Spell.CastWhileMoving && Player.Instance.PlayerMovement.IsMoving)
            {
                Debug.Log("PlayerIsMoving!");
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

        spellObject.GetComponent<SpellObject>().CastFired(targetManager.Target);
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
