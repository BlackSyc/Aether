using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public Shoulder Shoulder;

    public Inventory Inventory;

    public SpellSystem SpellSystem;

    private void Awake()
    {
        if (Instance)
            throw new Exception("There is more than one Player object in the scene!");

        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
