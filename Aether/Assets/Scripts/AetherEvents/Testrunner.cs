using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testrunner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InvokeNextFrame(ThrowCloakSpawningEvents));
    }

    private void ThrowCloakSpawningEvents()
    {
        AetherEvents.GameEvents.Puzzle1Events.CompleteStage2();
    }

    private IEnumerator InvokeNextFrame(Action action)
    {
        yield return null;
        action.Invoke();
    }

}
