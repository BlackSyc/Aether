using Aether.Core.Cloaks;
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
    }
}
