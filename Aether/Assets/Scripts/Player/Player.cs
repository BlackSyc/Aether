using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField]
    private CharacterController characterController;

    public CharacterController CharacterController => characterController;

    [SerializeField]
    private PlayerMovement playerMovement;

    public PlayerMovement PlayerMovement => playerMovement;

    [SerializeField]
    private Shoulder shoulder;

    public Shoulder Shoulder => shoulder;

    [SerializeField]
    private Inventory inventory;

    public Inventory Inventory => inventory;

    [SerializeField]
    private SpellSystem spellSystem;

    public SpellSystem SpellSystem => spellSystem;

    [SerializeField]
    private Interactor interactor;

    public Interactor Interactor => interactor;

    [SerializeField]
    private SkinnedMeshRenderer mesh;

    public SkinnedMeshRenderer Mesh => mesh;

    [SerializeField]
    private PlayerTargetManager targetManager;

    public PlayerTargetManager TargetManager => targetManager;

    [SerializeField]
    private Transform companionParent;

    public Transform CompanionParent => companionParent;

    [SerializeField]
    private AggroRelay aggroRelay;

    public AggroRelay AggroRelay => aggroRelay;

    [SerializeField]
    private Health health;

    public Health Health => health;

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
            Health.SetFullHealth();
            GetComponent<AggroTrigger>().IsActive = true;
        }
        else
        {
            transform.position = new Vector3(0, 1, 0);
            Health.SetFullHealth();
            GetComponent<AggroTrigger>().IsActive = true;
        }
    }

    private void Start()
    {
        Hint.Get("Movement").Activate();
    }
}
