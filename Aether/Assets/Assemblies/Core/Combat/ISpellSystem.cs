using Aether.Core.Combat.ScriptableObjects;

namespace Aether.Core.Combat { 
    public interface ISpellSystem
    {
        void AddSpell(int libraryIndex, Spell spell, bool makeActive = true);

        void RemoveSpell(int libraryIndex, Spell spell);
    }
}