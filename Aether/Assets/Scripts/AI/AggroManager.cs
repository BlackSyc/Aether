using Aether.TargetSystem;
using UnityEngine;

public interface AggroManager
{
    bool Contains(ICombatComponent target);

    (int aggro, ICombatComponent target) GetHighestAggroTarget(LayerMask layerMask);

    void AddAggroTarget(ICombatComponent target);

    void RemoveAggroTarget(ICombatComponent target);
    void IncreaseAggro(ICombatComponent target, int amount);

    void DecreaseAggro(ICombatComponent target, int amount);

}
