using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    [SerializeField]
    private AIState currentState;

    private void OnEnable()
    {
        currentState.Create(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    public void TransitionTo(AIState newState)
    {
        currentState.Destroy(this);
        currentState = newState;
        currentState.Create(this);
    }
}
