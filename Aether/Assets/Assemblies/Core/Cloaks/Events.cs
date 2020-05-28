using Aether.Core.Cloaks;
using Aether.Core.Cloaks.ScriptableObjects;
using System;

namespace Aether.Core.Cloaks
{
    public static class Events
    {
        public static event Action<ICloakProvider> OnInteract;

        public static void Interact(ICloakProvider cloakObject)
        {
            OnInteract?.Invoke(cloakObject);
        }

        public static event Action<Cloak> OnCloakEquipped;
        public static event Action<Cloak> OnCloakUnequipped;

        public static void CloakUnequipped(Cloak cloakInfo)
        {
            OnCloakUnequipped?.Invoke(cloakInfo);
        }

        public static void CloakEquipped(Cloak cloakInfo)
        {
            OnCloakEquipped?.Invoke(cloakInfo);
        }
    }
}
