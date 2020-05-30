using UnityEngine;

namespace Aether.Combat.TargetSystem
{
    internal interface ITargetSystem : Core.Combat.ITargetSystem
    {
        new ICombatSystem GetCurrentTarget(LayerMask layerMask);

        new Vector3 GetCurrentTargetExact(LayerMask layerMask);
    }
}
