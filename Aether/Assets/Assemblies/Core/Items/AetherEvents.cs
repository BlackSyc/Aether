using Aether.Core.Items.ScriptableObjects;
using System;

namespace Aether.Core.Items
{
    public static partial class AetherEvents
    {
        public struct KeystoneEvents
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
        }
    }
}
