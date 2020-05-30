using Aether.Core.Combat;
using System;

namespace Aether.Combat.Modifiers
{
    internal interface IModifierSlots : Core.Combat.IModifierSlots
    {
        new void AddModifier(IModifier modifier);

        void RemoveModifier(IModifier modifier);
    }
}
