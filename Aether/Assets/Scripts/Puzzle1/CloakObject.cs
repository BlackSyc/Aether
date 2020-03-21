using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakObject : MonoBehaviour
{
    public readonly struct Events
    {
        public static event Action<CloakObject> OnInteract;

        public static void Interact(CloakObject cloakObject)
        {
            OnInteract?.Invoke(cloakObject);
        }
    }

    [SerializeField]
    private float showDelay = 4;

    [SerializeField]
    private GameObject cloakObject;

    [SerializeField]
    private CloakInfo cloakInfo;

    public CloakInfo CloakInfo => cloakInfo;

    public void Equip()
    {
        Player.Instance.Shoulder.EquipCloak(cloakInfo);
        CheckEquip(cloakInfo);
    }

    public void Interact(Interactor interactor, Interactable interactable)
    {
        Events.Interact(this);
    }

    public void Unequip()
    {
        Player.Instance.Shoulder.UnequipCloak();
        CheckEquip(cloakInfo);
    }

    private void Start()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage2 += Show;
        AetherEvents.GameEvents.CloakEvents.OnCloakUnequipped += CheckEquip;
    }

    private void CheckEquip(CloakInfo cloakInfo)
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
        AetherEvents.GameEvents.CloakEvents.OnCloakUnequipped -= CheckEquip;
    }


}
