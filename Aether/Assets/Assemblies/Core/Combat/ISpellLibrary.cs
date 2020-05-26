using Aether.Core.Combat.ScriptableObjects;
using System;

namespace Aether.Core.Combat
{
    public interface ISpellLibrary
    {
        event Action<Spell> OnActiveSpellChanged;

        Spell ActiveSpell { get; }
        bool Contains(Spell spell);

        void Remove(Spell spell);

        void Add(Spell spell, bool makeActive = true);
    }
}