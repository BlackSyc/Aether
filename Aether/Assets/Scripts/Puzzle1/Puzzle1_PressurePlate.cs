using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_PressurePlate : MonoBehaviour
{
    public bool IsTriggered { get; set; }

    public Material GlowingMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puzzle1_Trigger") && !IsTriggered)
        {
            IsTriggered = true;
            GetComponent<MeshRenderer>().material = GlowingMaterial;

            AetherEvents.GameEvents.Puzzle1Events.PressurePlateTriggered();
        }
    }
}
