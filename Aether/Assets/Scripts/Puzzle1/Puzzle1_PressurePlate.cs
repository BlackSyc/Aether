using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_PressurePlate : MonoBehaviour
{
    public struct Events
    {
        public static event Action OnTriggered;

        public static void Triggered()
        {
            OnTriggered?.Invoke();
        }
    }

    public bool IsTriggered { get; set; }

    public Material GlowingMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puzzle1_Trigger") && !IsTriggered)
        {
            IsTriggered = true;
            GetComponent<MeshRenderer>().material = GlowingMaterial;

            Events.Triggered();
        }
    }
}
