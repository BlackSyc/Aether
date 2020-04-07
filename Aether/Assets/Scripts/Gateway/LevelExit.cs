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

    [SerializeField]
    private Transform exitPoint;

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
        Player.Instance.transform.position = exitPoint.position;
        Player.Instance.CharacterController.enabled = true;
        Player.Instance.Shoulder.EquipCloak(equippedCloak);

        SceneController.Instance.LoadedLevel.levelController.Disable();
    }
}
