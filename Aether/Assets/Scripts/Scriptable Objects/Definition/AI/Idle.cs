using Aether.TargetSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/AI/Idle")]
    public class Idle : AIState
    {

        [SerializeField]
        private AIState aggroState;

        public override void UpdateState(AIStateMachine stateMachine)
        {
            ITargetSystem targetSystem = stateMachine.GetComponent<ITargetSystem>();
            Health health = stateMachine.GetComponent<Health>();

            if (health && health.IsDead)
            {
                Destroy(stateMachine.gameObject);
            }

            if (targetSystem == null)
                return;

            if (targetSystem.GetCurrentTarget(stateMachine.gameObject.EnemyLayer()) != null)
            {
                stateMachine.TransitionTo(aggroState);
            }
        }
    }
}
