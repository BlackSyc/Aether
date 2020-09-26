using System;
using System.Collections;
using System.Collections.Generic;
using Syc.Combat;
using Syc.Combat.HealthSystem;
using UnityEngine;

public class Logger : MonoBehaviour
{
    private HealthSystem _healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        _healthSystem = GetComponent<ICombatSystem>().Get<HealthSystem>();
        _healthSystem.OnDamageReceived += HealthSystemOnOnDamageReceived;
    }

    private void HealthSystemOnOnDamageReceived(DamageRequest obj)
    {
        Debug.Log($"Damage Received: {obj.AmountDealt}");
    }

    private void OnDestroy()
    {
        _healthSystem.OnDamageReceived -= HealthSystemOnOnDamageReceived;

    }
}
