using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder : MonoBehaviour
{
    private void Start()
    {
        AetherEvents.GameEvents.CloakEvents.OnEquipCloak += EquipCloak;
    }

    private void EquipCloak(GameObject cloakPrefab)
    {
        GameObject cloak = Instantiate(cloakPrefab, transform);
        cloak.GetComponent<Cloth>().capsuleColliders = new CapsuleCollider[] { GetComponent<CapsuleCollider>() };
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.CloakEvents.OnEquipCloak -= EquipCloak;
    }
}
