using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder : MonoBehaviour
{
    public SpellSystem SpellSystem;

    private Cloak equippedCloak = null;

    private void Start()
    {
        AetherEvents.GameEvents.CloakEvents.OnEquipCloak += EquipCloak;
        AetherEvents.GameEvents.CloakEvents.OnUnequipCloak += UnequipCloak;
    }

    private void EquipCloak(CloakInfo cloakInfo)
    {
        if(equippedCloak != null)
            UnequipCloak();

        equippedCloak = cloakInfo.InstantiateCloak(transform);
        equippedCloak.Equip();

        equippedCloak.GetComponent<Cloth>().capsuleColliders = new CapsuleCollider[] { GetComponent<CapsuleCollider>() };
    }

    private void UnequipCloak()
    {
        equippedCloak?.Unequip();
        Destroy(equippedCloak.gameObject);
        equippedCloak = null;
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.CloakEvents.OnEquipCloak -= EquipCloak;
        AetherEvents.GameEvents.CloakEvents.OnUnequipCloak -= UnequipCloak;
    }
}
