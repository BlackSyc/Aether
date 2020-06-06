using System;

namespace Aether.Core.Cloaks
{
    public interface IShoulder
    {
        event Action<ICloak> OnCloakChanged;

        ICloak EquippedCloak { get; }

        void EquipCloak(ICloak cloak);

        void UnequipCloak();
    }
}
