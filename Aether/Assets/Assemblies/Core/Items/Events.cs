using Aether.Core.Items.ScriptableObjects;
using System;

namespace Aether.Core.Items
{
    public static partial class Events
    {
        public static event Action<Keystone> OnKeystoneActivated;
        public static event Action<Keystone> OnKeystoneDeactivated;

        public static void KeystoneActivated(Keystone keystone)
        {
            OnKeystoneActivated?.Invoke(keystone);
        }

        public static void KeystoneDeactivated(Keystone keystone)
        {
            OnKeystoneDeactivated?.Invoke(keystone);
        }
        public static event Action OnPickedUpKeystone;

        public static void PickedUpKeystone()
        {
            OnPickedUpKeystone?.Invoke();
        }

        public static event Action OnExtractedKeystone;

        public static void ExtractedKeystone()
        {
            OnExtractedKeystone?.Invoke();
        }
    }
}
