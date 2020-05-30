using System;

namespace Aether.Core.Combat
{
    public interface IModifierSlots
    {
        event Action<IModifier> OnModifierAdded;

        event Action<IModifier> OnModifierRemoved;
    }
}
