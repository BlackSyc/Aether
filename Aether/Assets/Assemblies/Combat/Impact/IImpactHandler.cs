using UnityEngine;

namespace Aether.Combat.Impact
{
    internal interface IImpactHandler
    {
        void HandleImpact(Vector3 impact);

        void HandleImpactAtPosition(Vector3 impact, Vector3 position);
    }
}
