using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : ScriptableObject
{
    [SerializeField]
    private string name;

    public virtual void FixedUpdateState(AIStateMachine stateMachine) { }

    public virtual void Create(AIStateMachine stateMachine) { }

    public virtual void Destroy(AIStateMachine stateMachine) { }
}
