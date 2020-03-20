using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;
using static AetherEvents;

public class AttunementDevice : MonoBehaviour
{
    public readonly struct Events
    {
        public static event Action<AttunementDevice> OnOpenAttunementWindow;

        public static void OpenAttunementWindow(AttunementDevice attunementDevice)
        {
            OnOpenAttunementWindow?.Invoke(attunementDevice);
        }
    }

    #region Private Fields
    private Keystone _activeKeystone = null;
    #endregion

    #region Serialized Fields
    [SerializeField]
    private List<Keystone> keystones;

    [SerializeField]
    private Aspect aspect;

    [SerializeField]
    private GameObject keystoneObject;
    #endregion

    #region Getters
    public ReadOnlyCollection<Keystone> Keystones => new ReadOnlyCollection<Keystone>(keystones);
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        Interactor.Events.OnProposeInteraction += PrepareInteraction;
    }

    private void OnDestroy()
    {
        Interactor.Events.OnProposeInteraction -= PrepareInteraction;
    }
    #endregion

    #region Public Methods
    public void Toggle(Keystone keystone)
    {
        if (keystone == null)
            return;

        if (keystone.IsActivated)
            Deactivate(keystone);
        else
            Activate(keystone);
    }

    // Interaction Handler
    public void Interact(Interactor interactor, Interactable _)
    {
        Inventory interactorInventory = interactor.GetComponentInParent<Inventory>();

        if (interactorInventory != null)
        {
            keystones.AddRange(interactorInventory.ExtractKeystones(x => x.Aspect == aspect));
        }

        Events.OpenAttunementWindow(this);
    }
    #endregion

    #region Private Methods
    private void Activate(Keystone keystone)
    {
        if(_activeKeystone != keystone)
        {
            if(_activeKeystone != null)
                _activeKeystone.Deactivate();

            _activeKeystone = keystone;
        }

        keystoneObject.SetActive(true);
        _activeKeystone.Activate();
    }

    private void Deactivate(Keystone keystone)
    {
        _activeKeystone = null;
        keystoneObject.SetActive(false);
        keystone.Deactivate();
    }

    private void PrepareInteraction(Interactable interactable, Interactor interactor)
    {
        if (interactable != GetComponent<Interactable>())
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
    #endregion
}
