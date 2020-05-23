using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    event Action<float> OnHealthChanged;

    event Action OnDied;

    event Action OnHealthObjectDestroyed;

    float CurrentHealth { get; }

    float MaxHealth { get; }

    bool IsDead { get; }

    void Damage(float damage);

    void Heal(float heal);

    Transform transform { get; }
}
