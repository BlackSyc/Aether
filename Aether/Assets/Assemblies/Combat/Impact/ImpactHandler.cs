using UnityEngine;

namespace Aether.Combat.Impact
{
    [RequireComponent(typeof(Rigidbody))]
    internal class ImpactHandler : MonoBehaviour, IImpactHandler
    {
        private Rigidbody rigidBody;

        public ICombatSystem CombatSystem { get; set; }

        // Start is called before the first frame update
        void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        public void HandleImpact(Vector3 impact)
        {
            rigidBody.AddForce(impact);
        }

        public void HandleImpactAtPosition(Vector3 impact, Vector3 position)
        {
            rigidBody.AddForceAtPosition(impact, position);
        }
    }
}
