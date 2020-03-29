using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

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

    public static Hint Custom(string message)
    {
        Hint defaultHint = Hints.SingleOrDefault(x => "Default".Equals(x.Name));
        defaultHint.HintPrefab.GetComponent<TextMeshProUGUI>().text = message;
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
