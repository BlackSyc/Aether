﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder : MonoBehaviour
{
    public SpellSystem SpellSystem;

    private Cloak equippedCloak = null;

    public Cloak EquippedCloak => equippedCloak;

    [SerializeField]
    private Spell defaultSpell;

    public void EnableCloakPhysics()
    {
        if (transform.GetChild(0) == null)
            return;

        transform.GetChild(0).GetComponent<Cloth>().enabled = true;
    }

    public void DisableCloakPhysics()
    {
        if (transform.GetChild(0) == null)
            return;

        transform.GetChild(0).GetComponent<Cloth>().enabled = false;
    }

    public void EquipCloak(Cloak cloak)
    {
        if(equippedCloak != null)
            UnequipCloak();

        equippedCloak = cloak;
        cloak.Equip(transform);
    }

    public void UnequipCloak()
    {
        var cloak = equippedCloak;
        equippedCloak = null;
        cloak?.Unequip();
        SpellSystem.SpellLibraries[0].SetActiveSpell(defaultSpell);
    }
}
