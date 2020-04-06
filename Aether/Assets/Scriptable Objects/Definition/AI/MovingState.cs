using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Scriptable Objects/AI/Moving State")]
public class MovingState : AIState
{
    [SerializeField]
    private NavMeshData navMesh;

    [SerializeField]
    private ScanningState scanningState;

    [SerializeField]
    private bool DEBUG_shouldTransition = false;

    public override void UpdateState(AIStateMachine stateMachine)
    {
        ExecuteStateBehaviour(stateMachine);
        TryTransition(stateMachine);
    }

    private void ExecuteStateBehaviour(AIStateMachine stateMachine)
    {
        Debug.Log("Moving state updated!");
    }

    private void TryTransition(AIStateMachine stateMachine)
    {
        if (DEBUG_shouldTransition)
        {
            stateMachine.TransitionTo(scanningState);
        }
    }
}
