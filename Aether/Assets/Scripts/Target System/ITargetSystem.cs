using UnityEngine;

namespace Aether.TargetSystem
{
    public interface ITargetSystem
    {
        ITarget GetCurrentTarget(LayerMask layerMask);
    }
}
