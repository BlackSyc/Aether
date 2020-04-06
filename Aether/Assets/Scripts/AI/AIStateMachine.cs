using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    [SerializeField]
    private AIState currentState;
    private void Start()
    {
        currentState.Create(this);
    }

    private void Update()
    {
         
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
