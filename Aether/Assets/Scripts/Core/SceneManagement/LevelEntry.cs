using Aether.Core.Cloaks;
using System;
using UnityEngine;

namespace Aether.Core.SceneManagement
{
    public class LevelEntry : MonoBehaviour
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
            if (other.tag.Equals("Player"))
            {
                TeleportToLevelOrigin();
            }
        }

        public void TeleportToLevelOrigin()
        {
            Events.EnteringLevel();
            SceneController.Instance.LoadedLevel.levelController.Enable();

            IShoulder playerShoulder = Player.Instance.Get<IShoulder>();
            CharacterController playerCharController = Player.Instance.Get<CharacterController>();

            ICloak equippedCloak = playerShoulder.EquippedCloak;
            playerShoulder.UnequipCloak();
            playerCharController.enabled = false;
            Player.Instance.transform.position = SceneController.Instance.LoadedLevel.levelController.GetEntryPoint().position;
            playerCharController.enabled = true;
            playerShoulder.EquipCloak(equippedCloak);

            SceneController.Instance.StartPlatformLevelController.Disable();
        }
    }
}