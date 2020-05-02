using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroTrigger : MonoBehaviour
{
    public event Action<int> GlobalAggroRaised;

    public bool IsActive = true;

    [SerializeField]
    private int bias = 0;

    public int Bias => bias;

    public void TriggerGlobalAggro(int amount)
    {
        GlobalAggroRaised?.Invoke(amount);
    }
}
