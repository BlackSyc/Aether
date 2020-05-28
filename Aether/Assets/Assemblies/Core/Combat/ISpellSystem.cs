using Aether.Core.Combat.ScriptableObjects;
using UnityEngine;

namespace Aether.Core.Combat { 
    public interface ISpellSystem
    {
        bool HasActiveSpells { get; }
        void AddSpell(int libraryIndex, Spell spell, bool makeActive = true);

        void RemoveSpell(int libraryIndex, Spell spell);

        LayerMask GetCombinedLayerMask();
    }
}