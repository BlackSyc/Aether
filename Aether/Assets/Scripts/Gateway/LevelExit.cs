using ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Cloak equippedCloak = Player.Instance.Shoulder.EquippedCloak;
        Player.Instance.Shoulder.UnequipCloak();
        Player.Instance.CharacterController.enabled = false;
        Player.Instance.transform.position = ExitPoint.position;
        Player.Instance.CharacterController.enabled = true;
        Player.Instance.Shoulder.EquipCloak(equippedCloak);

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
