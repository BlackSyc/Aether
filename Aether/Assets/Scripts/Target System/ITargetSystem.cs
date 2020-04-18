using UnityEngine;

namespace Aether.TargetSystem
{
    public interface ITargetSystem
    {
        Target GetCurrentTarget(LayerMask layerMask);
    }
}
