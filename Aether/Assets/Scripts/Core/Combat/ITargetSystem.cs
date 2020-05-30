using UnityEngine;

namespace Aether.Core.Combat
{
    public interface ITargetSystem
    {
        ICombatSystem GetCurrentTarget(LayerMask layerMask);

        Vector3 GetCurrentTargetExact(LayerMask layerMask);
    }
}
