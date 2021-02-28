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
    public class Player : NetworkedMonoSystemBase
    {
        [SerializeField]
        private List<MonoSubSystem> subSystems;

        public Transform CameraTransform => _cameraTransform;
        
        [SerializeField]
        private Transform _cameraTransform;

        private static Player Instance;

        private static HashSet<ILocalPlayerLink> _localPlayerSubscribers = new HashSet<ILocalPlayerLink>();
        
        private void Start()
        {
            foreach (var subSystem in subSystems)
            {
                AddSubsystem(subSystem);
            }
            
            if (IsLocalPlayer)
            {
                SetLocalPlayer(this);
            }
            Hints.Get("Movement").Activate();
        }

        private void OnDestroy()
        {
            if (IsLocalPlayer)
            {
                RemoveLocalPlayer(this);
            }
        }

        private static void SetLocalPlayer(Player player)
        {
            if (Instance)
                throw new Exception("There is more than one Player object in the game!");
            
            Instance = player;
            
            foreach (var localPlayerSubscriber in _localPlayerSubscribers)
            {
                localPlayerSubscriber.OnLocalPlayerLinked(Instance);
            }
        }

        private static void RemoveLocalPlayer(Player player)
        {
            Instance = null;
            foreach (var localPlayerSubscriber in _localPlayerSubscribers)
            {
                localPlayerSubscriber.OnLocalPlayerUnlinked(player);
            }
        }

        /// <summary>
        /// Subscribes to changes to the local player instance.
        /// If a local player is currently present, <see ILocalPlayerLink.OnLocalPlayerLinkedrSpawn"/>
        /// is triggered for that local player.
        /// </summary>
        /// <param name="localPlayerLink">The subscriber.</param>
        public static void LinkToLocalPlayer(ILocalPlayerLink localPlayerLink)
        {
            if (_localPlayerSubscribers.Contains(localPlayerLink))
            {
                return;
            }

            _localPlayerSubscribers.Add(localPlayerLink);
            if (Instance)
            {
                localPlayerLink.OnLocalPlayerLinked(Instance);
            }
        }

        public static void UnlinkFromLocalPlayer(ILocalPlayerLink localPlayerLink)
        {
            if (!_localPlayerSubscribers.Contains(localPlayerLink))
            {
                return;
            }
            
            _localPlayerSubscribers.Remove(localPlayerLink);
            if (Instance)
            {
                localPlayerLink.OnLocalPlayerUnlinked(Instance);
            }
        }
        
        public static void Respawn()
        {
            if (SceneController.Instance.LoadedLevel.buildIndex != null)
            {
                ILevelController levelController = SceneController.Instance.LoadedLevel.levelController;
                levelController.GetLevelExit().TeleportToStartPlatform();

                if (Instance.Has(out ICombatSystem combatSystem) && combatSystem.Has(out HealthSystem health))
                    health.Reset();

            }
            else
            {
                Instance.transform.position = new Vector3(0, 1, 0);

                if (Instance.Has(out ICombatSystem combatSystem) && combatSystem.Has(out HealthSystem health))
                    health.Reset();
            }
        }
    }
}
