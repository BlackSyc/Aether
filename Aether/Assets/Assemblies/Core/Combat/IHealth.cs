using System;

namespace Aether.Core.Combat
{
    public interface IHealth
    {
        event Action<float> OnHealthChanged;

        event Action OnDied;

        event Action OnHealthObjectDestroyed;

        void Heal(float heal);

        void Damage(float damage);

        float CurrentHealth { get; }

        float MaxHealth { get; }
    }
}
