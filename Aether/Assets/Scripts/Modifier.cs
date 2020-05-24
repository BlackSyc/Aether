using Aether.TargetSystem;
using System.Collections;
using UnityEngine;

public class Modifier
{
    public ModifierType ModifierType { get; private set; }

    public float FallOffTime { get; set; }

    public Coroutine Coroutine;

    public Modifier(ModifierType modifierType)
    {
        ModifierType = modifierType;
    }

    public IEnumerator ModifierCoroutine(ICombatSystem combatSystem)
    {
        FallOffTime = Time.time + ModifierType.Duration;
        return ModifierType.modifierCoroutine(combatSystem);
    }
}