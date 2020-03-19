using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField]
    private Aspect triggerConstraint;
    void Start()
    {
        AetherEvents.GameEvents.HubEvents.OnOpenStairs += SpawnPlatform;
        AetherEvents.GameEvents.HubEvents.OnCloseStairs += DespawnPlatform;
    }

    private void DespawnPlatform(Aspect aspect)
    {
        if (!aspect.Equals(triggerConstraint))
            return;

        GetComponent<Animator>().SetBool("Spawn", false);
    }

    private void SpawnPlatform(Aspect aspect)
    {
        if (!aspect.Equals(triggerConstraint))
            return;

        GetComponent<Animator>().SetBool("Spawn", true);
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.HubEvents.OnOpenStairs -= SpawnPlatform;
        AetherEvents.GameEvents.HubEvents.OnCloseStairs -= DespawnPlatform;
    }
}
