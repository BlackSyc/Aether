using System;

namespace Aether.Core.Combat
{
    public interface ISpellLibrary
    {
        event Action<ISpell> OnActiveSpellChanged;

        ISpell ActiveSpell { get; }
        bool Contains(ISpell spell);

        void Remove(ISpell spell);

        void Add(ISpell spell, bool makeActive = true);

        bool HasActiveSpell { get; }
    }
}