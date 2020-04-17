using ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class AttunementDevice : MonoBehaviour
{
    public readonly struct Events
    {
        public static event Action<AttunementDevice> OnInteract;

        public static void Interact(AttunementDevice attunementDevice)
        {
            OnInteract?.Invoke(attunementDevice);
        }
    }

    #region Private Fields

    private Keystone _activeKeystone = null;

    #endregion

    #region Serialized Fields

    [SerializeField]
    private List<Keystone> keystones;

    private List<Keystone> newKeystones = new List<Keystone>();

    [SerializeField]
    private Aspect aspect;

    [SerializeField]
    private TravellerPlatform _travellerPlatform;

    [SerializeField]
    private Traveller _traveller;

    [SerializeField]
    private GameObject keystoneObject;

    #endregion

    #region Getters
    public ReadOnlyCollection<Keystone> Keystones => keystones.AsReadOnly();

    public ReadOnlyCollection<Keystone> NewKeystones => newKeystones.AsReadOnly();
    #endregion

    #region Public Methods
    public void ApplyNewKeystones()
    {
        keystones.AddRange(newKeystones);
        newKeystones.Clear();
    }

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
            newKeystones.AddRange(interactorInventory.ExtractKeystones(x => x.Aspect == aspect));
        }

        Events.Interact(this);
    }

    public void PrepareForInteraction(Interactor interactor, Interactable interactable)
    {
        if (interactable != GetComponent<Interactable>())
            return;

        if (interactor.GetComponentInParent<Inventory>().Keystones.Count > 0)
        {
            interactable.ProposeInteractionMessage = "to place keystones";
        }
        else
        {
            interactable.ProposeInteractionMessage = "to activate a keystone";
        }
    }

    #endregion

    #region Private Methods

    private void Activate(Keystone keystone)
    {
        if(_activeKeystone != keystone)
        {
            if (_activeKeystone != null)
                Deactivate(_activeKeystone);

            _travellerPlatform.gameObject.SetActive(true);
            _traveller.gameObject.SetActive(true);
            _activeKeystone = keystone;
            _travellerPlatform.Traveller.TravelAnimation = _activeKeystone.TravelAnimation;
            _travellerPlatform.Traveller.SceneBuildIndex = _activeKeystone.SceneBuildIndex;
            
        }

        keystoneObject.SetActive(true);
        _activeKeystone.Activate();
    }

    private void Deactivate(Keystone keystone)
    {
        _travellerPlatform.gameObject.SetActive(false);
        _traveller.gameObject.SetActive(false);
        _travellerPlatform.Traveller.TravelAnimation = null;

        _activeKeystone = null;
        keystoneObject.SetActive(false);
        keystone.Deactivate();

        SceneController.Instance.UnloadLevel(keystone.SceneBuildIndex);
    }

    #endregion
}
