using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Keystone> keystones;

    public ReadOnlyCollection<Keystone> Keystones => new ReadOnlyCollection<Keystone>(keystones);

    public void PickupKeystone(Keystone keyStone)
    {
        keystones.Add(keyStone);
    }

    public List<Keystone> ExtractKeystones(Func<Keystone, bool> predicate)
    {
        IEnumerable<Keystone> keystonesToExtract = keystones.Where(predicate);
        List<Keystone> keystoneList = keystonesToExtract.ToList();
        keystones.RemoveAll(new Predicate<Keystone>(predicate));
        return keystoneList;
    }
}
