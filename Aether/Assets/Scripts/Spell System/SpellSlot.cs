using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpellSlot
{
    public Spell spell;

    public bool hasActiveSpell()
    {
        return spell != null;
    }
}
