using Aether.TargetSystem;
using NSubstitute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModifierSlots : MonoBehaviour, IModifierSlots
{
    public event Action<Modifier> OnModifierAdded;

    public event Action<Modifier> OnModifierRemoved;

    private List<Modifier> activeModifiers;
    public ICombatSystem CombatSystem { get; set; }

    private void Start()
    {
        activeModifiers = new List<Modifier>();
    }

    public void AddModifier(Modifier modifier)
    {
        var sameModifier = activeModifiers.SingleOrDefault(x => x.ModifierType == modifier.ModifierType);
        if(sameModifier != null)
        {
            sameModifier.FallOffTime = Time.time + sameModifier.ModifierType.Duration;
            return;
        }


        activeModifiers.Add(modifier);
        modifier.Coroutine = StartCoroutine(modifier.ModifierCoroutine(CombatSystem));
        OnModifierAdded?.Invoke(modifier);
    }

    public void RemoveModifier(Modifier modifier)
    {
        activeModifiers.Remove(modifier);

        StopCoroutine(modifier.Coroutine);
        OnModifierRemoved?.Invoke(modifier);
    }

    private void Update()
    {
        activeModifiers.RemoveAll(x =>
        {
            if (x.FallOffTime < Time.time)
            {
                StopCoroutine(x.Coroutine);
                OnModifierRemoved?.Invoke(x);
                return true;
            }
            return false;
        });
    }
}
