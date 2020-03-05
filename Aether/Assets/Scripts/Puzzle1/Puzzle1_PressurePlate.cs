using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_PressurePlate : MonoBehaviour
{
    public bool IsTriggered { get; set; }

    [SerializeField]
    private Puzzle1_Manager puzzleManager;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puzzle1_Trigger") && !IsTriggered)
        {
            puzzleManager.Trigger(this);
        }
    }
}
