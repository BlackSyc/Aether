namespace Aether.Core.Combat
{
    public interface IHealth
    {
        void Heal(float heal);

        float CurrentHealth { get; }

        float MaxHealth { get; }
    }
}
