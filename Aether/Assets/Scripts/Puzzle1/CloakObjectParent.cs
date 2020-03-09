﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakObjectParent : MonoBehaviour
{
    [SerializeField]
    private float showDelay = 4;

    [SerializeField]
    private GameObject cloakObject;

    [SerializeField]
    private CloakInfo cloakInfo;

    private void Start()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage2 += Show;
        AetherEvents.GameEvents.CloakEvents.OnEquipCloak += CloakEquipped;
        AetherEvents.GameEvents.CloakEvents.OnUnequipCloak += CloakUnequipped;
    }

    private void CloakUnequipped()
    {
        CheckEquip();
    }

    private void CloakEquipped(CloakInfo cloakInfo)
    {
        CheckEquip();
    }

    private void CheckEquip()
    {
        if (cloakInfo.IsEquipped)
        {
            cloakObject.SetActive(false);
        }
        else
        {
            cloakObject.SetActive(true);
        }
    }

    private void Show()
    {
        StartCoroutine(ShowAfter(showDelay));
    }

    private IEnumerator ShowAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        cloakObject.SetActive(true);
        GetComponent<Interactable>().IsActive = true;
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage2 -= Show;
        AetherEvents.GameEvents.CloakEvents.OnEquipCloak -= CloakEquipped;
        AetherEvents.GameEvents.CloakEvents.OnUnequipCloak -= CloakUnequipped;
    }


}
