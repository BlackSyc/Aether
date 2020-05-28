using Aether.Core;
using Aether.Core.Cloaks;
using Aether.Core.Cloaks.ScriptableObjects;
using Aether.Core.Interaction;
using System;
using System.Collections;
using UnityEngine;

internal class CloakProvider : MonoBehaviour, ICloakProvider
{
    [SerializeField]
    private float showDelay = 4;

    [SerializeField]
    private GameObject cloakObject;

    [SerializeField]
    private Cloak cloak;

    public Cloak Cloak => cloak;

    public void Equip()
    {
        Player.Instance.Shoulder.EquipCloak(cloak);
        CheckEquip(cloak);
    }

    public void Interact(IInteractor interactor, IInteractable interactable)
    {
        Events.Interact(this);
    }

    public void Unequip()
    {
        Player.Instance.Shoulder.UnequipCloak();
        CheckEquip(cloak);
    }

    private void Start()
    {
        Cloak.Events.OnCloakEquipped += CheckEquip;
        Cloak.Events.OnCloakUnequipped += CheckEquip;
        StartCoroutine(ShowAfter(showDelay));
    }

    private void CheckEquip(Cloak cloak)
    {
        if (cloak != Cloak)
            return;

        if (Cloak.IsEquipped)
        {
            cloakObject.SetActive(false);
        }
        else
        {
            cloakObject.SetActive(true);
        }
    }

    private IEnumerator ShowAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        cloakObject.SetActive(true);
        GetComponent<IInteractable>().IsActive = true;
    }

    private void OnDestroy()
    {
        Cloak.Events.OnCloakEquipped -= CheckEquip;
        Cloak.Events.OnCloakUnequipped -= CheckEquip;
    }
}
