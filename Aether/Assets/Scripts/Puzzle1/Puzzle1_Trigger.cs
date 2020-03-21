using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Puzzle1_Manager.Events.OnStage1Completed += Destroy;
    }

    private void Destroy()
    {
        Puzzle1_Manager.Events.OnStage1Completed -= Destroy;
        Destroy(this.gameObject);
    }
}
