using UnityEngine;

namespace Aether.TargetSystem
{
    [RequireComponent(typeof(AggroManager))]
    public class AITargetSystem : MonoBehaviour, ITargetSystem
    {
        [SerializeField]
        private int minimumTargetAggro = 5;

        
        private AggroManager aggroManager;

        public Target GetCurrentTarget(LayerMask layerMask)
        {
            (int aggro, AggroTrigger trigger) highestAggroTrigger = aggroManager.GetHighestAggroTrigger(layerMask);
            if(highestAggroTrigger.aggro >= minimumTargetAggro)
            {
                return new Target(highestAggroTrigger.trigger.transform);
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
