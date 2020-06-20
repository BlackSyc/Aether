using System;

namespace Aether.Core.Combat
{
    public interface IModifierSlots
    {
        event Action<IModifierType> OnModifierAdded;

        event Action<IModifierType> OnModifierRemoved;

        void AddModifier(IModifierType modifier);
    }
}
