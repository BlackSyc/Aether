using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    [SerializeField]
    private AIState currentState;

    private void Update()
    {
        currentState.UpdateState(this);   
    }

    public void TransitionTo(AIState newState)
    {
        currentState = newState;
    }
}
