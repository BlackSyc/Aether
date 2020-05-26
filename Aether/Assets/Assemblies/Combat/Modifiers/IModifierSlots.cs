using System;

namespace Aether.Combat.Modifiers
{
    internal interface IModifierSlots : Core.Combat.IModifierSlots
    {
        event Action<IModifier> OnModifierAdded;

        event Action<IModifier> OnModifierRemoved;

        void AddModifier(IModifier modifier);

        void RemoveModifier(IModifier modifier);
    }
}
