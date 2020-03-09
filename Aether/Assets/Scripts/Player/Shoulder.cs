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

    private void EquipCloak(GameObject cloakPrefab)
    {
        if(equippedCloak != null)
            UnequipCloak();

        GameObject cloak = Instantiate(cloakPrefab, transform);
        cloak.GetComponent<Cloth>().capsuleColliders = new CapsuleCollider[] { GetComponent<CapsuleCollider>() };
        equippedCloak = cloak.GetComponent<Cloak>();
        equippedCloak.Equip();
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
