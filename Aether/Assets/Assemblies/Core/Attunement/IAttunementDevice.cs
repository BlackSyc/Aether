using Aether.Core.Items.ScriptableObjects;
using System.Collections.ObjectModel;

namespace Aether.Core.Attunement
{
    public interface IAttunementDevice
    {
        ReadOnlyCollection<Keystone> Keystones { get; }

        ReadOnlyCollection<Keystone> NewKeystones { get; }

        void ApplyNewKeystones();

        void Toggle(Keystone keystone);
    }
}
