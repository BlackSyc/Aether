using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : ScriptableObject
{
    [SerializeField]
    private string name;

    public abstract void UpdateState(AIStateMachine stateMachine);
}
