using System;
using UnityEngine;

namespace Aether.StartPlatform
{
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
            if (other.CompareTag("Player") && !IsTriggered)
            {
                IsTriggered = true;
                transform.parent.GetComponent<MeshRenderer>().material = GlowingMaterial;

                Events.Triggered();
            }
        }
    }
}
