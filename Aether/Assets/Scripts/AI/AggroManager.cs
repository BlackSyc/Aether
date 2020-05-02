using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AggroManager
{
    bool Contains(AggroTrigger trigger);

    (int aggro, AggroTrigger trigger) GetHighestAggroTrigger(LayerMask layerMask);

    void AddAggroTrigger(AggroTrigger aggroTrigger);

    void RemoveAggroTrigger(AggroTrigger aggroTrigger);
    void IncreaseAggro(AggroTrigger aggroTrigger, int amount);

    void DecreaseAggro(AggroTrigger aggroTrigger, int amount);

}
