using Aether.Combat.AggroSystem;
using UnityEngine;

namespace Aether.Combat.TargetSystem
{
    [RequireComponent(typeof(AggroSystem.IAggroManager))]
    internal class AITargetSystem : MonoBehaviour, ITargetSystem
    {
        [SerializeField]
        private int minimumTargetAggro = 5;

        
        private AggroSystem.IAggroManager aggroManager;

        public ICombatSystem GetCurrentTarget(LayerMask layerMask)
        {
            (int aggro, ICombatSystem target) highestAggroTarget = aggroManager.GetHighestAggroTarget(layerMask);
            if(highestAggroTarget.aggro >= minimumTargetAggro)
            {
                return highestAggroTarget.target;
            }

            return null;
        }

        public Vector3 GetCurrentTargetExact(LayerMask layerMask)
        {
            throw new System.NotImplementedException();
        }

        Core.Combat.ICombatSystem Core.Combat.ITargetSystem.GetCurrentTarget(LayerMask layerMask)
        {
            return GetCurrentTarget(layerMask);
        }

        // Start is called before the first frame update
        void Start()
        {
            aggroManager = GetComponent<AggroSystem.IAggroManager>();
        }
    }
}
