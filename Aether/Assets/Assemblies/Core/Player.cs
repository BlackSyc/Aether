using Aether.Core.Combat;
using Aether.Core.SceneManagement;
using Aether.Core.Tutorial;
using System;
using UnityEngine;

namespace Aether.Core
{
    public class Player : CoreSystemBehaviour
    {
        public static Player Instance { get; private set; }

        private void Awake()
        {
            if (Instance)
                throw new Exception("There is more than one Player object in the game!");

            Instance = this;
        }

        public void Respawn()
        {
            if (SceneController.Instance.LoadedLevel.buildIndex != null)
            {
                ILevelController levelController = SceneController.Instance.LoadedLevel.levelController;
                levelController.GetLevelExit().TeleportToStartPlatform();

                if (base.Has(out ICombatSystem combatSystem) && combatSystem.Has(out IHealth health))
                    health.Heal(health.MaxHealth);

            }
            else
            {
                transform.position = new Vector3(0, 1, 0);

                if (base.Has(out ICombatSystem combatSystem) && combatSystem.Has(out IHealth health))
                    health.Heal(health.MaxHealth);
            }
        }

        private void Start()
        {
            Hints.Get("Movement").Activate();
        }
    }
}
