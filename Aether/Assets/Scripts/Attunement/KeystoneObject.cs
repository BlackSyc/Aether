using System;
using Aether.Assets.Assemblies.Core.Items;
using Aether.Core;
using Aether.Core.Items.ScriptableObjects;
using Aether.Core.Tutorial;
using UnityEngine;

namespace Aether.Attunement
{
    public class KeystoneObject : MonoBehaviour, ILocalPlayerLink
    {
        [SerializeField]
        private Keystone keystone;

        private Player _player;

        private void Awake()
        {
            Player.LinkToLocalPlayer(this);
        }

        private void OnDestroy()
        {
            Player.UnlinkFromLocalPlayer(this);
        }

        public void PickUp()
        {
            if (!_player)
            {
                return;
            }
            
            if (keystone.IsFound)
            {
                Hints.Get("Keystone_AlreadyPickedUp").Activate();
                return;
            }
            _player.Get<IInventory>().PickupKeystone(keystone);
            Destroy(gameObject);
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
