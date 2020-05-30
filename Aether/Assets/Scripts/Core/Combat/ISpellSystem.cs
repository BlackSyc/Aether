using System;
using UnityEngine;

namespace Aether.Core.Combat { 
    public interface ISpellSystem
    {
        bool HasActiveSpells { get; }
        void AddSpell(int libraryIndex, ISpell spell, bool makeActive = true);

        void RemoveSpell(int libraryIndex, ISpell spell);

        ISpellLibrary GetSpellLibrary(int index);

        LayerMask GetCombinedLayerMask();

        event Action<ISpellCast> OnSpellIsCast;
    }
}