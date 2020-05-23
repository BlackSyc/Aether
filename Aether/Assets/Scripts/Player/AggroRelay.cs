using Aether.TargetSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRelay : MonoBehaviour, AggroManager
{
    public AggroManager AggroManager;

    public void AddAggroTarget(ITarget target)
    {
        if (AggroManager == null)
            return;

        AggroManager.AddAggroTarget(target);
    }

    public bool Contains(ITarget target)
    {
        if (AggroManager == null)
            return false;

        return AggroManager.Contains(target);
    }

    public void DecreaseAggro(ITarget target, int amount)
    {
        if (AggroManager == null)
            return;

        AggroManager.DecreaseAggro(target, amount);
    }

    public (int aggro, ITarget target) GetHighestAggroTarget(LayerMask layerMask)
    {
        if (AggroManager == null)
            return (0, null);

        return AggroManager.GetHighestAggroTarget(layerMask);
    }

    public void IncreaseAggro(ITarget target, int amount)
    {
        if (AggroManager == null)
            return;

        AggroManager.IncreaseAggro(target, amount);
    }

    public void RemoveAggroTarget(ITarget target)
    {
        if (AggroManager == null)
            return;

        AggroManager.RemoveAggroTarget(target);
    }
}
