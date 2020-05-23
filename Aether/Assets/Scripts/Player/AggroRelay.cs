using Aether.TargetSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRelay : MonoBehaviour, AggroManager
{
    public AggroManager AggroManager;

    public void AddAggroTarget(ICombatComponent target)
    {
        if (AggroManager == null)
            return;

        AggroManager.AddAggroTarget(target);
    }

    public bool Contains(ICombatComponent target)
    {
        if (AggroManager == null)
            return false;

        return AggroManager.Contains(target);
    }

    public void DecreaseAggro(ICombatComponent target, int amount)
    {
        if (AggroManager == null)
            return;

        AggroManager.DecreaseAggro(target, amount);
    }

    public (int aggro, ICombatComponent target) GetHighestAggroTarget(LayerMask layerMask)
    {
        if (AggroManager == null)
            return (0, null);

        return AggroManager.GetHighestAggroTarget(layerMask);
    }

    public void IncreaseAggro(ICombatComponent target, int amount)
    {
        if (AggroManager == null)
            return;

        AggroManager.IncreaseAggro(target, amount);
    }

    public void RemoveAggroTarget(ICombatComponent target)
    {
        if (AggroManager == null)
            return;

        AggroManager.RemoveAggroTarget(target);
    }
}
