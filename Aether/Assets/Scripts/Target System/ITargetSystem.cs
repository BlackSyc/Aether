using UnityEngine;

namespace Aether.TargetSystem
{
    public interface ITargetSystem
    {
        ICombatComponent GetCurrentTarget(LayerMask layerMask);

        Vector3 GetCurrentTargetExact(LayerMask layerMask);
    }
}
