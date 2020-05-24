﻿using UnityEngine;

namespace Aether.Combat.TargetSystem
{
    [RequireComponent(typeof(AggroManager))]
    public class AITargetSystem : MonoBehaviour, ITargetSystem
    {
        [SerializeField]
        private int minimumTargetAggro = 5;

        
        private AggroManager aggroManager;

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

        // Start is called before the first frame update
        void Start()
        {
            aggroManager = GetComponent<AggroManager>();
        }
    }
}
