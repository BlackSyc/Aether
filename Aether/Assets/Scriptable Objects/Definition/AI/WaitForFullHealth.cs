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
        if (Player.Instance.Companion != null)
        {
            Destroy(stateMachine.gameObject);
            return;
        }

        Health healthComponent = stateMachine.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.OnHealthChanged += _ =>
            {
                if (healthComponent.IsFullHealth)
                {
                    stateMachine.gameObject.AddComponent<Companion>();
                    Player.Instance.Companion = stateMachine.gameObject.GetComponent<Companion>();
                    stateMachine.TransitionTo(nextState);
                }
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
                {
                    stateMachine.gameObject.AddComponent<Companion>();
                    Player.Instance.Companion = stateMachine.GetComponent<Companion>();
                    stateMachine.TransitionTo(nextState);
                }
            };
        }
    }

    public override void UpdateState(AIStateMachine stateMachine)
    {
        Health health = stateMachine.GetComponent<Health>();

        if (health && health.IsDead)
        {
            Destroy(stateMachine.gameObject);
        }
    }
}
