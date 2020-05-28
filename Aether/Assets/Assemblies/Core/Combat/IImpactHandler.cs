using UnityEngine;

namespace Aether.Core.Combat
{
    public interface IImpactHandler
    {
        void HandleImpact(Vector3 impact);

        void HandleImpactAtPosition(Vector3 impact, Vector3 position);
    }
}
