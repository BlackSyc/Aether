using Aether.Core.Cloaks;
using System;
using UnityEngine;

namespace Aether.Core.SceneManagement
{
    public class LevelExit : MonoBehaviour
    {
        public struct Events
        {
            public static event Action OnExitingLevel;

            public static void ExitingLevel()
            {
                OnExitingLevel?.Invoke();
            }
        }

        public Transform ExitPoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                TeleportToStartPlatform();
            }
        }

        public void TeleportToStartPlatform()
        {
            Events.ExitingLevel();
            SceneController.Instance.StartPlatformLevelController.Enable();

            IShoulder playerShoulder = Player.Instance.Get<IShoulder>();
            CharacterController playerCharController = Player.Instance.Get<CharacterController>();

            ICloak equippedCloak = playerShoulder.EquippedCloak;
            playerShoulder.UnequipCloak();
            playerCharController.enabled = false;
            Player.Instance.transform.position = ExitPoint.position;
            playerCharController.enabled = true;
            playerShoulder.EquipCloak(equippedCloak);

            SceneController.Instance.LoadedLevel.levelController.Disable();


            SceneController.Events.OnLevelStartedUnloading += LevelStartedUnloading;
            SceneController.Instance.UnloadLevel(SceneController.Instance.LoadedLevel.buildIndex.Value);
        }
        private void LevelStartedUnloading(int buildIndex, AsyncOperation unloadingLevelOperation)
        {
            unloadingLevelOperation.completed += x =>
                {
                    ReloadLevel(buildIndex);
                    SceneController.Events.OnLevelStartedUnloading -= LevelStartedUnloading;
                };
        }

        private void ReloadLevel(int buildIndex)
        {
            SceneController.Instance.LoadLevel(buildIndex);
        }
    }
}
