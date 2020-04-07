using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public struct Events
    {
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
    [SerializeField]
    private List<Keystone> keystones;

    public ReadOnlyCollection<Keystone> Keystones => new ReadOnlyCollection<Keystone>(keystones);

    public void PickupKeystone(Keystone keyStone)
    {
        keyStone.Found();
        keystones.Add(keyStone);
        Events.PickedUpKeystone();
    }

    public List<Keystone> ExtractKeystones(Func<Keystone, bool> predicate)
    {
        IEnumerable<Keystone> keystonesToExtract = keystones.Where(predicate);
        List<Keystone> keystoneList = keystonesToExtract.ToList();
        keystones.RemoveAll(new Predicate<Keystone>(predicate));

        if(keystoneList.Count > 0)
        {
            Events.ExtractedKeystone();
        }

        return keystoneList;
    }

    public bool ContainsKeystone(Func<Keystone, bool> predicate)
    {
        return keystones.Any(predicate);
    }
}
