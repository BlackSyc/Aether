using UnityEngine;

namespace Aether.TargetSystem
{
    public interface ITargetSystem
    {
        ICombatComponent GetCurrentTarget(LayerMask layerMask);
    }
}
