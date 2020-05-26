using Aether.Combat.Modifiers;
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

        public void SetModifier(Modifier modifier)
        {
            Modifier = modifier;
            image.sprite = modifier.ModifierType.Icon;
        }

        public void Update()
        {
            if (Modifier != null)
                durationText.text = ((int)(Modifier.FallOffTime - Time.time)).ToString();
        }
    }
}
