using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/AI/Wait for full health")]
public class WaitForFullHealth : AIState
{
    [SerializeField]
    private AIState nextState;

    public override void Create(AIStateMachine stateMachine)
    {
        Health healthComponent = stateMachine.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.OnHealthChanged += _ =>
            {
                if (healthComponent.IsFullHealth)
                    stateMachine.TransitionTo(nextState);
            };
        }
    }

    public override void Destroy(AIStateMachine stateMachine)
    {
        Health healthComponent = stateMachine.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.OnHealthChanged -= _ =>
            {
                if (healthComponent.IsFullHealth)
                    stateMachine.TransitionTo(nextState);
            };
        }
    }
}
