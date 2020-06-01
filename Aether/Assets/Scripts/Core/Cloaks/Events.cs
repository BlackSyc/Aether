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

        public static event Action<ICloak> OnCloakEquipped;
        public static event Action<ICloak> OnCloakUnequipped;

        public static void CloakUnequipped(ICloak cloakInfo)
        {
            OnCloakUnequipped?.Invoke(cloakInfo);
        }

        public static void CloakEquipped(ICloak cloakInfo)
        {
            OnCloakEquipped?.Invoke(cloakInfo);
        }
    }
}
