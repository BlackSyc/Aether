using System;

namespace Aether.Core.Combat
{
    public interface IHealth
    {
        event Action<float> OnHealthChanged;

        event Action OnDied;

        event Action OnHealthObjectDestroyed;

        void ChangeHealth(float healthDelta);

        float CurrentHealth { get; }

        float MaxHealth { get; }

        bool IsDead { get; }
    }
}
