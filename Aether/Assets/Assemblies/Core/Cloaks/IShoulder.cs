using Aether.Core.Cloaks.ScriptableObjects;

namespace Aether.Core.Cloaks
{
    public interface IShoulder
    {
        Cloak EquippedCloak { get; }

        void EquipCloak(Cloak cloak);

        void UnequipCloak();
    }
}
