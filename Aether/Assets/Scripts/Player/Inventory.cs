using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Keystone> Keystones { get; private set; }

    private void Start()
    {
        Keystones = new List<Keystone>();
        AetherEvents.GameEvents.InventoryEvents.OnPickupKeystone += PickupKeystone;  
    }

    public void PickupKeystone(Keystone keyStone)
    {
        Keystones.Add(keyStone);
    }

    public void ClearKeystones()
    {
        Keystones.Clear();
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.InventoryEvents.OnPickupKeystone -= PickupKeystone;
    }





}
