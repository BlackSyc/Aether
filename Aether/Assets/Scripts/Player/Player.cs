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
    private TargetManager targetManager;

    public TargetManager TargetManager => targetManager;

    [SerializeField]
    private Transform companionParent;

    public Transform CompanionParent => companionParent;

    private void Awake()
    {
        if (Instance)
            throw new Exception("There is more than one Player object in the game!");

        Instance = this;
    }

    private void Start()
    {
        Hint.Get("Movement").Activate();
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
