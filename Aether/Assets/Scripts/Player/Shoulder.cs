using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder : MonoBehaviour
{
    public SpellSystem SpellSystem;

    private Cloak equippedCloak = null;

    public void EquipCloak(CloakInfo cloakInfo)
    {
        if(equippedCloak != null)
            UnequipCloak();

        equippedCloak = cloakInfo.InstantiateCloak(transform);
        equippedCloak.Equip();

        equippedCloak.GetComponent<Cloth>().capsuleColliders = new CapsuleCollider[] { GetComponent<CapsuleCollider>() };
    }

    public void UnequipCloak()
    {
        equippedCloak?.Unequip();
        Destroy(equippedCloak.gameObject);
        equippedCloak = null;
    }
}
