using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage1 += Destroy;
    }

    private void Destroy()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage1 -= Destroy;
        Destroy(this.gameObject);
    }
}
