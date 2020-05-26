using Aether.Core.Cloaks.ScriptableObjects;
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

            Cloak equippedCloak = Player.Instance.Shoulder.EquippedCloak;
            Player.Instance.Shoulder.UnequipCloak();
            Player.Instance.CharacterController.enabled = false;
            Player.Instance.transform.position = SceneController.Instance.LoadedLevel.levelController.GetEntryPoint().position;
            Player.Instance.CharacterController.enabled = true;
            Player.Instance.Shoulder.EquipCloak(equippedCloak);

            SceneController.Instance.StartPlatformLevelController.Disable();
        }
    }
}