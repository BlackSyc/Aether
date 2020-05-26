using System;
using UnityEngine;

namespace Aether.Combat.Health
{
    internal interface IHealth : Core.Combat.IHealth
    {
        event Action<float> OnHealthChanged;

        event Action OnDied;

        event Action OnHealthObjectDestroyed;

        bool IsDead { get; }

        void Damage(float damage);

        Transform transform { get; }
    }
}
