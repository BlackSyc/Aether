using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Aether.Core.Tutorial
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Hints/HintLoader")]
    public class Hints : ScriptableObject
    {
        [SerializeField]
        private List<Hint> hints;

        private static Hints instance;


        public static Hint Get(string name)
        {
            return instance.hints.SingleOrDefault(x => name.Equals(x.Name));
        }

        public static Hint Custom(string title, string message)
        {
            Hint defaultHint = Get("Custom");
            defaultHint.HintPrefab.GetComponent<CustomHint>().HeaderText.text = title;
            defaultHint.HintPrefab.GetComponent<CustomHint>().ContentText.text = message;
            return defaultHint;
        }

        private void OnEnable()
        {
            instance = this;
        }

        private void OnDisable()
        {
            instance = null;
        }
    }
}
