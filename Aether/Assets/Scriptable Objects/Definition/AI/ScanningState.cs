using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Scriptable Objects/AI/Scanning State")]
public class ScanningState : AIState
{
    [SerializeField]
    private MovingState movingState;

    public override void UpdateState(AIStateMachine stateMachine)
    {
    }

}
