using Aether.Core.Cloaks.ScriptableObjects;
using System;
using System.Runtime.Serialization;

namespace Aether.Core.Cloaks
{
    public interface IShoulder
    {
        Cloak EquippedCloak { get; }

        void EquipCloak(Cloak cloak);

        void UnequipCloak();
    }
}
