using Aether.TargetSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private IHealth health;

    public void SetHealth(IHealth health)
    {
        this.health = health;
    }

    private void Update()
    {
        if(health != null)
            UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        GetComponent<Animation>()["Health"].speed = 0;
        GetComponent<Animation>()["Health"].time = health.CurrentHealth / health.MaxHealth;
    }

}
