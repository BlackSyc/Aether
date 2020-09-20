using Syc.Combat.ModifierSystem;
using Syc.Combat.ModifierSystem.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aether.UserInterface.Combat
{
    public class ModifierIcon : MonoBehaviour
    {
        public Modifier Modifier { get; private set; }

        [SerializeField]
        private Image image;

        [SerializeField]
        private TextMeshProUGUI durationText;

        public void SetModifierBehaviour(Modifier modifier)
        {
            Modifier = modifier;
            image.sprite = modifier.ModifierBehaviour.Icon.sprite;
        }

        public void Update()
        {
            if (Modifier != null)
                durationText.text = ((int) (Modifier.ModifierBehaviour.Duration - Modifier.ActiveDuration)).ToString();
        }
    }
}
