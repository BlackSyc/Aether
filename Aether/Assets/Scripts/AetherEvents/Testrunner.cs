using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testrunner : MonoBehaviour
{
    [SerializeField]
    private List<Keystone> keystones;

    [SerializeField]
    private bool spawnCloaks;

    [SerializeField]
    private bool pickupKeystones;

    private void Start()
    {
        if (spawnCloaks)
            InvokeNextFrame(SpawnCloaks);

        if (pickupKeystones)
            InvokeNextFrame(PickupKeystone);
    }

    [ContextMenu("Spawn Cloaks")]
    private void SpawnCloaks()
    {
        AetherEvents.GameEvents.Puzzle1Events.CompleteStage2();
    }

    [ContextMenu("Pick up Keystone")]
    private void PickupKeystone()
    {
        keystones.ForEach(x => AetherEvents.GameEvents.InventoryEvents.Pickup(x));
    }

    #region Invokers
    private void InvokeNextFrame(Action action)
    {
        StartCoroutine(ExecuteNextFrame(action));
    }

    private IEnumerator ExecuteNextFrame(Action action)
    {
        yield return null;
        action.Invoke();
    }
    #endregion
}
