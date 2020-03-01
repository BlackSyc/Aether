using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Child : MonoBehaviour
{
    public bool IsTriggered { get; private set; }

    [SerializeField]
    private Puzzle1_Manager puzzleManager;

    [SerializeField]
    private Material triggeredMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puzzle1_Trigger") && !IsTriggered)
        {
            Debug.Log("Triggered one puzzlepiece!");
            IsTriggered = true;
            GetComponent<MeshRenderer>().material = triggeredMaterial;
            puzzleManager.CheckPuzzleComplete();
        }
    }
}
