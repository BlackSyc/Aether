using Aether.TargetSystem;
using UnityEngine;

public interface AggroManager
{
    bool Contains(ICombatSystem target);

    (int aggro, ICombatSystem target) GetHighestAggroTarget(LayerMask layerMask);

    void AddAggroTarget(ICombatSystem target);

    void RemoveAggroTarget(ICombatSystem target);
    void IncreaseAggro(ICombatSystem target, int amount);

    void DecreaseAggro(ICombatSystem target, int amount);

}
