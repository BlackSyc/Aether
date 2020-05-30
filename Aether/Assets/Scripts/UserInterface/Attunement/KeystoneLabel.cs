using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Attunement
{
    public class KeystoneLabel : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        public void SetText(string labelText)
        {
            _text.text = labelText;
        }
    }

}