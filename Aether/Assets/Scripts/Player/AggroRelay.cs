using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRelay : MonoBehaviour, AggroManager
{
    public AggroManager AggroManager;

    public void AddAggroTrigger(AggroTrigger aggroTrigger)
    {
        if (AggroManager == null)
            return;

        AggroManager.AddAggroTrigger(aggroTrigger);
    }

    public bool Contains(AggroTrigger trigger)
    {
        if (AggroManager == null)
            return false;

        return AggroManager.Contains(trigger);
    }

    public void DecreaseAggro(AggroTrigger aggroTrigger, int amount)
    {
        if (AggroManager == null)
            return;

        AggroManager.DecreaseAggro(aggroTrigger, amount);
    }

    public (int aggro, AggroTrigger trigger) GetHighestAggroTrigger(LayerMask layerMask)
    {
        if (AggroManager == null)
            return (0, null);

        return AggroManager.GetHighestAggroTrigger(layerMask);
    }

    public void IncreaseAggro(AggroTrigger aggroTrigger, int amount)
    {
        if (AggroManager == null)
            return;

        AggroManager.IncreaseAggro(aggroTrigger, amount);
    }

    public void RemoveAggroTrigger(AggroTrigger aggroTrigger)
    {
        if (AggroManager == null)
            return;

        AggroManager.RemoveAggroTrigger(aggroTrigger);
    }
}
