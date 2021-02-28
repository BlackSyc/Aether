using System;
using Aether.Core;
using Aether.Core.Cloaks;
using Syc.Core.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aether.UserInterface.Cloaks
{
    public class CloakWindow : MonoBehaviour, ILocalPlayerLink
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

        private Player _player;

        private void Awake()
        {
            Player.LinkToLocalPlayer(this);
        }

        private void OnDestroy()
        {
            Player.UnlinkFromLocalPlayer(this);
        }

        public CloakWindow Link(CloakProviderUILink uiLink)
        {
            _uiLink = uiLink;
            _cloakProvider = _uiLink.CloakProvider;
            return this;
        }

        public CloakWindow Build(Interactor interactor)
        {
            header.text = _cloakProvider.Cloak.Name;
            keywords.text = _cloakProvider.Cloak.Keywords;
            content.text = _cloakProvider.Cloak.Description;

            if (_player == null)
            {
                return this;
            }

            bool playerEquipped = _player.Get<IShoulder>().EquippedCloak == _cloakProvider.Cloak;
            if (!playerEquipped)
            {
                equipButton.onClick.AddListener(() => _cloakProvider.Equip(interactor));
                equipButtonText.text = "Equip";
            }
            else
            {
                equipButton.onClick.AddListener(() => _cloakProvider.Unequip(interactor));
                equipButtonText.text = "Unequip";
            }
            return this;
        }

        public void RequestCloseWindow()
        {
            _uiLink.CloseWindow();
        }

        public void OnLocalPlayerLinked(Player player)
        {
            _player = player;
        }

        public void OnLocalPlayerUnlinked(Player player)
        {
            _player = null;
        }
    }
}
