using System;

namespace Aether.Core.Combat
{
    public interface IHealth
    {
        event Action<float> OnHealthChanged;

        event Action OnDied;

        event Action OnHealthObjectDestroyed;

        void Heal(float heal);

        float CurrentHealth { get; }

        float MaxHealth { get; }
    }
}
