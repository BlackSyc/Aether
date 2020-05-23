using Aether.TargetSystem;
using UnityEngine;

public interface AggroManager
{
    bool Contains(ITarget target);

    (int aggro, ITarget target) GetHighestAggroTarget(LayerMask layerMask);

    void AddAggroTarget(ITarget target);

    void RemoveAggroTarget(ITarget target);
    void IncreaseAggro(ITarget target, int amount);

    void DecreaseAggro(ITarget target, int amount);

}
