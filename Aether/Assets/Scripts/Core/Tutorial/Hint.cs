using System;
using UnityEngine;


namespace Aether.Core.Tutorial
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
