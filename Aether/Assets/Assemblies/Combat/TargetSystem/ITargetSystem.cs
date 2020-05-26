using UnityEngine;

namespace Aether.Combat.TargetSystem
{
    internal interface ITargetSystem : Core.Combat.ITargetSystem
    {
        ICombatSystem GetCurrentTarget(LayerMask layerMask);

        Vector3 GetCurrentTargetExact(LayerMask layerMask);
    }
}
