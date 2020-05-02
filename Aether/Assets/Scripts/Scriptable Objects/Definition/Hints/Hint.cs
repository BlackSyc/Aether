using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Hint")]
    public class Hint : ScriptableObject
    {
        public struct Events
        {
            public static event Action<Hint> OnActivated;

            public static void Activated(Hint hint)
            {
                OnActivated?.Invoke(hint);
            }
        }

        public string Name;

        public GameObject HintPrefab;

        public void Activate()
        {
            Events.Activated(this);
        }
    }
}
