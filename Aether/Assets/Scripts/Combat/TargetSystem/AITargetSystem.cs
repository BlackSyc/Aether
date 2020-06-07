using Aether.Core.Combat;
using UnityEngine;

namespace Aether.Combat.TargetSystem
{
    [RequireComponent(typeof(AggroSystem.IAggroManager))]
    internal class AITargetSystem : MonoBehaviour, ITargetSystem
    {
        [SerializeField]
        private int minimumTargetAggro = 5;


        private AggroSystem.IAggroManager aggroManager;

        public Target GetCurrentTarget()
        {

            return null;
        }

        // Start is called before the first frame update
        void Start()
        {
            aggroManager = GetComponent<AggroSystem.IAggroManager>();
        }
    }
}
