using Aether.Assets.Assemblies.Core.Items;
using Aether.Core.Items.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Aether.Items
{
    public class Inventory : MonoBehaviour, IInventory
    {
        [SerializeField]
        private List<Keystone> keystones;

        public ReadOnlyCollection<Keystone> Keystones => new ReadOnlyCollection<Keystone>(keystones);

        public void PickupKeystone(Keystone keyStone)
        {
            keyStone.Found();
            keystones.Add(keyStone);
            Core.Items.Events.PickedUpKeystone();
        }

        public List<Keystone> ExtractKeystones(Func<Keystone, bool> predicate)
        {
            IEnumerable<Keystone> keystonesToExtract = keystones.Where(predicate);
            List<Keystone> keystoneList = keystonesToExtract.ToList();
            keystones.RemoveAll(new Predicate<Keystone>(predicate));

            if (keystoneList.Count > 0)
            {
                Core.Items.Events.ExtractedKeystone();
            }

            return keystoneList;
        }

        public bool ContainsKeystone(Func<Keystone, bool> predicate)
        {
            return keystones.Any(predicate);
        }
    }
}