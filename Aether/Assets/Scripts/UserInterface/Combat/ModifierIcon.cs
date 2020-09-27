using System.Globalization;
using Syc.Combat.ModifierSystem;
using Syc.Combat.ModifierSystem.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aether.UserInterface.Combat
{
    public class ModifierIcon : MonoBehaviour
    {
        public ModifierState ModifierState { get; private set; }

        [SerializeField]
        private Image image;

        [SerializeField]
        private TextMeshProUGUI durationText;

        [SerializeField] private TextMeshProUGUI stacksText;

        public void SetModifierState(ModifierState modifierState)
        {
            ModifierState = modifierState;
            
            if(modifierState.ModifierType.Icon != null)
                image.sprite = modifierState.ModifierType.Icon;
        }

        public void Update()
        {
            if (ModifierState == null)
                return;
            
            durationText.text = ((int)ModifierState.TimeRemaining).ToString(CultureInfo.InvariantCulture);
            var stacks = ModifierState.Stacks;
            stacksText.text = stacks < 1 
                ? string.Empty
                : stacks.ToString();
        }
    }
}
