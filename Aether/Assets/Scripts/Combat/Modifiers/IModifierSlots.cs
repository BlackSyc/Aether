using System;

namespace Aether.Combat.Modifiers
{
    public interface IModifierSlots : ICombatComponent
    {
        event Action<Modifier> OnModifierAdded;

        event Action<Modifier> OnModifierRemoved;

        void AddModifier(Modifier modifier);

        void RemoveModifier(Modifier modifier);
    }
}
