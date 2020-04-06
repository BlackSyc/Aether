using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellObject : MonoBehaviour
{
    public Spell Spell;

    public bool CastOnSelf = false;

    public abstract void CastStarted();

    public abstract void CastInterrupted();

    public abstract void CastCanceled();

    public abstract void CastFired(Target target);

}
