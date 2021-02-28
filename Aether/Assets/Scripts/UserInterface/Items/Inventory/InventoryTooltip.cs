using System;
using Aether.Assets.Assemblies.Core.Items;
using Aether.Core;
using Aether.Core.Cloaks;
using Aether.Core.Extensions;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Inventory
{
    public class InventoryTooltip : MonoBehaviour, ILocalPlayerLink
    {

        [SerializeField]
        private TextMeshProUGUI contentText;

        private Player _player;

        private void Awake()
        {
            Player.LinkToLocalPlayer(this);
        }

        private void OnDestroy()
        {
            Player.UnlinkFromLocalPlayer(this);
        }

        public void Show()
        {
            if (!_player)
            {
                return;
            }
            
            var playerShoulder = _player.Get<IShoulder>();
            
            contentText.text = string.Empty;


            _player.Get<IInventory>().Keystones
                 .Where(x => x.Aspect == playerShoulder.EquippedCloak.Aspect)
                 .ForEach(keystone => contentText.text += $"\n'{keystone.Name}' Keystone");

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
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
