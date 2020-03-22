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

    [SerializeField]
    private TravellerPlatform _travellerPlatform;

    [SerializeField]
    private Traveller _traveller;

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
            _travellerPlatform.gameObject.SetActive(false);
            _traveller.gameObject.SetActive(false);
            _travellerPlatform.Traveller.TravelAnimation = null;
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
            _travellerPlatform.gameObject.SetActive(true);
            _traveller.gameObject.SetActive(true);
            _travellerPlatform.Traveller.TravelAnimation = _activeKeystone.TravelAnimation;
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
