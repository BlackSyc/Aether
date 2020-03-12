using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testrunner : MonoBehaviour
{
    [SerializeField]
    private List<Keystone> keystones;

    [ContextMenu("Spawn Cloaks")]
    private void InvokeCloakSpawn()
    {
        AetherEvents.GameEvents.Puzzle1Events.CompleteStage2();
    }

    [ContextMenu("Pick up Keystone")]
    private void PickupKeystone()
    {
        keystones.ForEach(x => AetherEvents.GameEvents.InventoryEvents.Pickup(x));
        
    }

}
