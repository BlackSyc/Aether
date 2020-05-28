using Aether.Core.Items.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Aether.Assets.Assemblies.Core.Items
{
    public interface IInventory
    {
        List<Keystone> ExtractKeystones(Func<Keystone, bool> predicate);

        bool ContainsKeystone(Func<Keystone, bool> predicate);

        ReadOnlyCollection<Keystone> Keystones { get; }



    }
}
