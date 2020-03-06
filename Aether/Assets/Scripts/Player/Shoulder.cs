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

    private void EquipCloak(CloakInfo cloakInfo)
    {
        GameObject cloak = Instantiate(cloakInfo.CloakPrefab, transform);
        cloak.GetComponent<Cloth>().capsuleColliders = new CapsuleCollider[] { GetComponent<CapsuleCollider>() };
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.CloakEvents.OnEquipCloak -= EquipCloak;
    }
}
