using UnityEngine;

namespace Aether.TargetSystem
{
    [RequireComponent(typeof(AggroManager))]
    public class AITargetSystem : MonoBehaviour, ITargetSystem
    {
        [SerializeField]
        private int minimumTargetAggro = 5;

        
        private AggroManager aggroManager;

        public ITarget GetCurrentTarget(LayerMask layerMask)
        {
            (int aggro, ITarget target) highestAggroTarget = aggroManager.GetHighestAggroTarget(layerMask);
            if(highestAggroTarget.aggro >= minimumTargetAggro)
            {
                return highestAggroTarget.target;
            }

            return null;
        }

        // Start is called before the first frame update
        void Start()
        {
            aggroManager = GetComponent<AggroManager>();
        }
    }
}
