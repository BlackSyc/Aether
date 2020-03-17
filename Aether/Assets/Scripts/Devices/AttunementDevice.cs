﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttunementDevice : MonoBehaviour
{
    [SerializeField]
    private List<Keystone> _keystones;

    [SerializeField]
    private GameObject _keystoneObject;

    [SerializeField]
    private Aspect triggerConstraint;

    private Keystone _activeKeystone = null;

    private void Start()
    {
        AetherEvents.GameEvents.InteractionEvents.OnProposeInteraction += PrepareInteraction;
        AetherEvents.GameEvents.AttunementEvents.OnToggleAttunement += ToggleAttunement;
    }

    private void ToggleAttunement(Keystone keystone)
    {
        if (keystone == null)
            return;

        if (!keystone.Aspect.Equals(triggerConstraint))
            return;

        if(_activeKeystone != null)
        {
            _activeKeystone.State.IsActivated = false;
            _keystoneObject.SetActive(false);
            AetherEvents.GameEvents.AttunementEvents.KeystoneDeactivated(_activeKeystone);
        }

        if (keystone == _activeKeystone)
        {
            _activeKeystone = null;
            return;
        }
        else
        {
            _activeKeystone = keystone;
            _activeKeystone.State.IsActivated = true;
            _keystoneObject.SetActive(true);
            Debug.Log(string.Format("Keystone {0} activated!", _activeKeystone.Name));
            AetherEvents.GameEvents.AttunementEvents.KeystoneActivated(_activeKeystone);
        }
    }

    private void PrepareInteraction(Interactable interactable, Interactor interactor)
    {
        if (interactable != this.GetComponent<Interactable>())
            return;

        if(interactor.GetComponentInParent<Inventory>().Keystones.Count > 0)
        {
            interactable.ProposeInteractionMessage = "to place keystones";
        }
        else
        {
            interactable.ProposeInteractionMessage = "to activate a keystone";
        }
    }

    public void Interact(Interactor interactor, Interactable _)
    {
        Inventory interactorInventory = interactor.GetComponentInParent<Inventory>();

        if(interactorInventory != null)
        {
            _keystones.AddRange(interactorInventory.Keystones);
            interactorInventory.ClearKeystones();
        }

        AetherEvents.GameEvents.AttunementEvents.OpenAttunementWindow(_keystones);
    }
}
