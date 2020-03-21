using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player Instance => instance;

    [SerializeField]
    private CharacterController characterController;

    public CharacterController CharacterController => characterController;

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

    private void Awake()
    {
        if (Instance)
            throw new Exception("There is more than one Player object in the scene!");

        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
