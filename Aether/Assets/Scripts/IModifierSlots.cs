using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModifierSlots : ICombatComponent
{
    event Action<Modifier> OnModifierAdded;

    event Action<Modifier> OnModifierRemoved;

    void AddModifier(Modifier modifier);

    void RemoveModifier(Modifier modifier);
}
