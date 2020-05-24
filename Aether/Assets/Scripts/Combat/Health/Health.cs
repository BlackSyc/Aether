﻿using System;
using UnityEngine;

namespace Aether.Combat.Health.Private
{
    internal class Health : MonoBehaviour, IHealth, ICombatComponent
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

        public event Action OnHealthObjectDestroyed;

        public event Action OnDied;

        public void HealthChanged(float delta)
        {
            OnHealthChanged?.Invoke(delta);
        }

        public void HealthObjectDestroyed()
        {
            OnHealthObjectDestroyed?.Invoke();
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

        public bool IsFullHealth => CurrentHealth == MaxHealth;

        public bool IsDead => CurrentHealth == 0;

        public ICombatSystem CombatSystem { get; set; }

        private void Start()
        {
            Events.HealthActivated(this);
        }

        public void Damage(float damage)
        {
            ChangeHealth(-damage);
        }

        public void Heal(float heal)
        {
            ChangeHealth(heal);
        }

        public void SetFullHealth()
        {
            float healthDelta = maxHealth - currentHealth;
            currentHealth = maxHealth;
            HealthChanged(healthDelta);
        }


        public void ChangeHealth(float delta)
        {
            currentHealth += delta;
            currentHealth = CurrentHealth >= 0 ? CurrentHealth : 0;
            currentHealth = CurrentHealth <= MaxHealth ? CurrentHealth : MaxHealth;
            HealthChanged(delta);
            if (currentHealth == 0)
            {
                Died();
            }
        }

        private void OnDestroy()
        {
            HealthObjectDestroyed();
        }
    }
}