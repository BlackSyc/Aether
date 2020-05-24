using Aether.Combat;
using Aether.Combat.Health.Private;
using ScriptableObjects;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField]
    private CombatSystem combatSystem;

    public ICombatSystem CombatSystem => (ICombatSystem) combatSystem;

    [SerializeField]
    private CharacterController characterController;

    public CharacterController CharacterController => characterController;

    [SerializeField]
    private PlayerMovementSystem playerMovement;

    public PlayerMovementSystem PlayerMovement => playerMovement;

    [SerializeField]
    private Shoulder shoulder;

    public Shoulder Shoulder => shoulder;

    [SerializeField]
    private Inventory inventory;

    public Inventory Inventory => inventory;

    [SerializeField]
    private Interactor interactor;

    public Interactor Interactor => interactor;

    [SerializeField]
    private SkinnedMeshRenderer mesh;

    public SkinnedMeshRenderer Mesh => mesh;

    [SerializeField]
    private Transform companionParent;

    public Transform CompanionParent => companionParent;

    [SerializeField]
    private AggroRelay aggroRelay;

    public AggroRelay AggroRelay => aggroRelay;

    public Companion Companion;

    private void Awake()
    {
        if (Instance)
            throw new Exception("There is more than one Player object in the game!");

        Instance = this;
    }

    public void Respawn()
    {
        if(SceneController.Instance.LoadedLevel.buildIndex != null)
        {
            ILevelController levelController = SceneController.Instance.LoadedLevel.levelController;
            levelController.GetLevelExit().TeleportToStartPlatform();
            CombatSystem.Get<Health>().SetFullHealth();
        }
        else
        {
            transform.position = new Vector3(0, 1, 0);
            CombatSystem.Get<Health>().SetFullHealth();
        }
    }

    private void Start()
    {
        Hints.Get("Movement").Activate();
    }
}
