using System;
using UnityEngine;

namespace Aether.Core.Combat
{
    public interface ISpellSystem
    {
        Transform CastOrigin { get; }
        bool HasActiveSpells { get; }
        void AddSpell(int libraryIndex, ISpell spell, bool makeActive = true);

        void RemoveSpell(int libraryIndex, ISpell spell);

        void RemoveAllSpells();

        ISpellLibrary GetSpellLibrary(int index);

        event Action<ISpellCast> OnSpellIsCast;

        void CastSpell(int index, Target target);
    }
}