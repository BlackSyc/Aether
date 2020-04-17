using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/AI/Idle")]
    public class Idle : AIState
    {
        [SerializeField]
        private int aggroLimit;

        [SerializeField]
        private AIState aggroState;

        public override void UpdateState(AIStateMachine stateMachine)
        {
            AggroTable aggroTable = stateMachine.GetComponent<AggroTable>();
            Health health = stateMachine.GetComponent<Health>();

            if (health && health.IsDead)
            {
                Destroy(stateMachine.gameObject);
            }

            if (aggroTable == null)
                return;

            (int aggro, AggroTrigger trigger) highestAggroTrigger = aggroTable.GetHighestAggroTrigger();
            if (highestAggroTrigger.trigger && highestAggroTrigger.aggro >= aggroLimit)
            {
                stateMachine.TransitionTo(aggroState);
            }
        }
    }
}
