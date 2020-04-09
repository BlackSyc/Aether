﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellObject : MonoBehaviour
{
    public Spell Spell;

    public GameObject Caster;

    public bool CastOnSelf = false;

    public abstract void CastStarted();

    public abstract void CastInterrupted();

    public abstract void CastCanceled();

    public virtual void CastFired(Target target)
    {
        AggroTrigger aggroTrigger = Caster.GetComponent<AggroTrigger>();
        if (aggroTrigger != null)
            aggroTrigger.RaiseGlobalAggro(Spell.GlobalAggro);
    }

}
