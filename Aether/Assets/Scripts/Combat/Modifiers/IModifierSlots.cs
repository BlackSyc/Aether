using System;

namespace Aether.Combat.Modifiers
{
    internal interface IModifierSlots : Core.Combat.IModifierSlots
    {
        void AddModifier(IModifier modifier);

        void RemoveModifier(IModifier modifier);
    }
}
