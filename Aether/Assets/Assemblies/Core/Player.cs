using Aether.Assets.Assemblies.Core.Items;
using Aether.Core.Cloaks;
using Aether.Core.Combat;
using Aether.Core.Companion;
using Aether.Core.Interaction;
using Aether.Core.Movement;
using Aether.Core.SceneManagement;
using Aether.Core.Tutorial;
using System;
using UnityEngine;

namespace Aether.Core
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        [SerializeField]
        private ICombatSystem combatSystem;

        public ICombatSystem CombatSystem => (ICombatSystem)combatSystem;

        [SerializeField]
        private CharacterController characterController;

        public CharacterController CharacterController => characterController;

        [SerializeField]
        private IMovementSystem playerMovement;

        public IMovementSystem PlayerMovement => playerMovement;

        [SerializeField]
        private IShoulder shoulder;

        public IShoulder Shoulder => shoulder;

        [SerializeField]
        private IInventory inventory;

        public IInventory Inventory => inventory;

        [SerializeField]
        private IInteractor interactor;

        public IInteractor Interactor => interactor;

        [SerializeField]
        private SkinnedMeshRenderer mesh;

        public SkinnedMeshRenderer Mesh => mesh;

        [SerializeField]
        private Transform companionParent;

        public Transform CompanionParent => companionParent;

        [SerializeField]
        private IAggroManager aggroRelay;

        public IAggroManager AggroRelay => aggroRelay;

        public ICompanion Companion;

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
                CombatSystem.Get<IHealth>().Heal(CombatSystem.Get<IHealth>().MaxHealth);
            }
            else
            {
                transform.position = new Vector3(0, 1, 0);
                CombatSystem.Get<IHealth>().Heal(CombatSystem.Get<IHealth>().MaxHealth);
            }
        }

        private void Start()
        {
            Hints.Get("Movement").Activate();
        }
    }
}
