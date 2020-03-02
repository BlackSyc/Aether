using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneMissile : SpellObject
{
    public override void CastCanceled()
    {
        Debug.Log("Arcane Missile Cancelled!");
    }

    public override void CastStarted()
    {
        Debug.Log("Arcane Missile Cast started!");
    }

    public override void CastFired()
    {
        Debug.Log("Arcane Missile Fired!");
    }

    public override void CastInterrupted()
    {
        Debug.Log("Arcane Missile Interrupted!");
    }
}
