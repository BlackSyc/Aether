using Aether.Core.Cloaks;
using System;
using UnityEngine;

namespace Aether.Core.SceneManagement
{
    public class LevelEntry : MonoBehaviour, ILocalPlayerLink
    {
        public struct Events
        {
            public static event Action OnEnteringLevel;

            public static void EnteringLevel()
            {
                OnEnteringLevel?.Invoke();
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            // if (other.tag.Equals("Player"))
            // {
            //     TeleportToLevelOrigin();
            // }
        }
        
        private Player _player;

        private void Awake()
        {
            Player.LinkToLocalPlayer(this);
        }

        private void OnDestroy()
        {
            Player.UnlinkFromLocalPlayer(this);
        }

        public void OnLocalPlayerLinked(Player player)
        {
            _player = player;
        }

        public void OnLocalPlayerUnlinked(Player player)
        {
            _player = null;
        }

        public void TeleportToLevelOrigin()
        {
            Events.EnteringLevel();
            SceneController.Instance.LoadedLevel.levelController.Enable();

            IShoulder playerShoulder = _player.Get<IShoulder>();
            CharacterController playerCharController = _player.Get<CharacterController>();

            ICloak equippedCloak = playerShoulder.EquippedCloak;
            playerShoulder.UnequipCloak();
            playerCharController.enabled = false;
            _player.transform.position = SceneController.Instance.LoadedLevel.levelController.GetEntryPoint().position;
            playerCharController.enabled = true;
            playerShoulder.EquipCloak(equippedCloak);

            SceneController.Instance.StartPlatformLevelController.Disable();
        }

    }
}