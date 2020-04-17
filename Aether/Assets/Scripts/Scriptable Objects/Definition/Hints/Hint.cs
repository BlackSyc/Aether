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

        public static List<Hint> Hints = new List<Hint>();

        public static Hint Get(string name)
        {
            return Hints.SingleOrDefault(x => name.Equals(x.Name));
        }

        public static Hint Custom(string title, string message)
        {
            Hint defaultHint = Hints.SingleOrDefault(x => "Custom".Equals(x.Name));
            defaultHint.HintPrefab.GetComponent<CustomHint>().HeaderText.text = title;
            defaultHint.HintPrefab.GetComponent<CustomHint>().ContentText.text = message;
            return defaultHint;
        }

        public string Name;

        public GameObject HintPrefab;

        public void Activate()
        {
            Events.Activated(this);
        }

        private void OnEnable()
        {
            Hints.Add(this);
        }

        private void OnDisable()
        {
            Hints.Remove(this);
        }
    }
}
