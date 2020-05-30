using System;

namespace Aether.Core.Attunement
{
    public static class Events
    {
        public static event Action<IAttunementDevice> OnInteract;

        public static void Interact(IAttunementDevice attunementDevice)
        {
            OnInteract?.Invoke(attunementDevice);
        }
    }
}
