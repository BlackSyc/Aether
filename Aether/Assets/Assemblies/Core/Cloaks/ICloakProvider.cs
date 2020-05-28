using Aether.Core.Cloaks.ScriptableObjects;

namespace Aether.Core.Cloaks
{
    public interface ICloakProvider
    {
        Cloak Cloak { get; }

        void Equip();

        void Unequip();
    }
}
