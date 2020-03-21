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
        Instance = this;
    }
}
