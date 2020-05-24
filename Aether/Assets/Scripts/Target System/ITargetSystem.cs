using UnityEngine;

namespace Aether.TargetSystem
{
    public interface ITargetSystem
    {
        ICombatSystem GetCurrentTarget(LayerMask layerMask);

        Vector3 GetCurrentTargetExact(LayerMask layerMask);
    }
}
