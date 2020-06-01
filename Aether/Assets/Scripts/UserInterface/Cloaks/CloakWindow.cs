using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Aether.Core.Cloaks;
using Aether.Input;
using Aether.Core;

namespace Aether.UserInterface.Cloaks
{
    public class CloakWindow : MonoBehaviour
    {

        [SerializeField]
        private TextMeshProUGUI header;

        [SerializeField]
        private TextMeshProUGUI keywords;

        [SerializeField]
        private TextMeshProUGUI content;

        [SerializeField]
        private Button equipButton;

        [SerializeField]
        private TextMeshProUGUI equipButtonText;

        [SerializeField]
        private GameObject window;

        private ICloakProvider _cloakProvider;

        private CloakProviderUILink _uiLink;

        public CloakWindow Link(CloakProviderUILink uiLink)
        {
            _uiLink = uiLink;
            _cloakProvider = _uiLink.CloakProvider;
            return this;
        }

        public CloakWindow Build()
        {
            header.text = _cloakProvider.Cloak.Name;
            keywords.text = _cloakProvider.Cloak.Keywords;
            content.text = _cloakProvider.Cloak.Description;

            bool playerEquipped = Player.Instance.Get<IShoulder>().EquippedCloak == _cloakProvider.Cloak;
            if (!playerEquipped)
            {
                equipButton.onClick.AddListener(() => _cloakProvider.Equip());
                equipButtonText.text = "Equip";
            }
            else
            {
                equipButton.onClick.AddListener(() => _cloakProvider.Unequip());
                equipButtonText.text = "Unequip";
            }
            return this;
        }

        public void RequestCloseWindow()
        {
            _uiLink.CloseWindow();
        }
    }
}
