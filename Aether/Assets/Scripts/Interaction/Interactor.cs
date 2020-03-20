using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using System.Linq;
using System;
using static AetherEvents;

public static partial class AetherEvents
{
    public struct InteractionEvents
    {
        public static event Action<Interactable, Interactor> OnProposeInteraction;
        public static event Action OnCancelProposeInteraction;
        public static event Action OnInteract;

        public static void ProposeInteraction(Interactable interactable, Interactor interactor)
        {
            OnProposeInteraction?.Invoke(interactable, interactor);
        }

        public static void CancelProposeInteraction()
        {
            OnCancelProposeInteraction?.Invoke();
        }

        public static void Interact()
        {
            OnInteract?.Invoke();
        }
    }
}

public class Interactor : MonoBehaviour
{
    public GameObject Player => transform.parent.gameObject;

    [SerializeField]
    private float interactionRadius = 1;

    [SerializeField]
    private LayerMask layers;

    private Interactable currentInteractable;

    public bool IsActive = true;

    public void CancelCurrentlyProposedInteraction()
    {
        if(currentInteractable != null)
        {
            currentInteractable = null;
            InteractionEvents.CancelProposeInteraction();
        }
    }

    public void Interact(CallbackContext context)
    {
        if (context.performed)
        {
            currentInteractable?.Interact(with: this);
            InteractionEvents.Interact();
        }
    }

    public void CheckForInteractables()
    {
        Interactable interactable = Physics.OverlapSphere(this.transform.position, interactionRadius, layers)
            .Where(x => x.GetComponent<Interactable>() != null)
            .Select(x => x.GetComponent<Interactable>())
            .FirstOrDefault(x => x.IsActive);
        if (interactable != null)
        {
            currentInteractable = interactable;
            InteractionEvents.ProposeInteraction(currentInteractable, this);
        }
        else
        {
            currentInteractable = null;
            InteractionEvents.CancelProposeInteraction();
        }
    }

    private void Update()
    {
        if(IsActive)
            CheckForInteractables();
    }
}
