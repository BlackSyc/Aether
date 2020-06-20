using Aether.Core.Combat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aether.UserInterface.Combat
{
    public class ModifierIcon : MonoBehaviour
    {
        public IModifierType Modifier { get; private set; }

        [SerializeField]
        private Image image;

        [SerializeField]
        private TextMeshProUGUI durationText;

        public void SetModifier(IModifierType modifier)
        {
            Modifier = modifier;
            image.sprite = Modifier.ModifierType.Icon;
        }

        public void Update()
        {
            if (Modifier != null)
                durationText.text = ((int)(Modifier.FallOffTime - Time.time)).ToString();
        }
    }
}
