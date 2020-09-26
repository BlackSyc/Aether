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

        public void SetModifierState(ModifierState modifierState)
        {
            ModifierState = modifierState;
            image.sprite = modifierState.Modifier.Icon.sprite;
        }

        public void Update()
        {
            if (ModifierState != null)
                durationText.text = ((int) (ModifierState.Modifier.Duration - ModifierState.ActiveDuration)).ToString();
        }
    }
}
