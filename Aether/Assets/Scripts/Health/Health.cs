using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public struct Events
    {
        public static event Action<Health> OnHealthActivated;

        public static void HealthActivated(Health health)
        {
            OnHealthActivated?.Invoke(health);
        }
    }

    public event Action<float> OnHealthChanged;

    public event Action OnDied;

    public void HealthChanged(float delta)
    {
        OnHealthChanged?.Invoke(delta);
    }

    public void Died()
    {
        OnDied?.Invoke();
    }

    [SerializeField]
    private float currentHealth = 1000;

    public float CurrentHealth => currentHealth;

    [SerializeField]
    private float maxHealth = 1000;

    public float MaxHealth => maxHealth;

    private void Start()
    {
        Events.HealthActivated(this);
    }

    public void ChangeHealth(float delta)
    {
        currentHealth += delta;
        currentHealth = CurrentHealth >= 0 ? CurrentHealth : 0;
        currentHealth = CurrentHealth <= MaxHealth ? CurrentHealth : MaxHealth;
        HealthChanged(delta);
        if(currentHealth == 0)
        {
            Died();
        }
    }
}
