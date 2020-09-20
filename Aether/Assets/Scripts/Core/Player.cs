using Aether.Core.SceneManagement;
using Aether.Core.Tutorial;
using System;
using System.Collections.Generic;
using Syc.Combat;
using Syc.Combat.HealthSystem;
using Syc.Core.System;
using UnityEngine;

namespace Aether.Core
{
    public class Player : MonoSystemBase
    {
        [SerializeField]
        private List<MonoSubSystem> subSystems;
        
        public static Player Instance { get; private set; }

        private void Awake()
        {
            if (Instance)
                throw new Exception("There is more than one Player object in the game!");

            Instance = this;
            foreach (var subSystem in subSystems)
            {
                AddSubsystem(subSystem);
            }
        }

        public void Respawn()
        {
            if (SceneController.Instance.LoadedLevel.buildIndex != null)
            {
                ILevelController levelController = SceneController.Instance.LoadedLevel.levelController;
                levelController.GetLevelExit().TeleportToStartPlatform();

                if (Has(out ICombatSystem combatSystem) && combatSystem.Has(out HealthSystem health))
                    health.Reset();

            }
            else
            {
                transform.position = new Vector3(0, 1, 0);

                if (Has(out ICombatSystem combatSystem) && combatSystem.Has(out HealthSystem health))
                    health.Reset();
            }
        }

        private void Start()
        {
            Hints.Get("Movement").Activate();
        }
    }
}
