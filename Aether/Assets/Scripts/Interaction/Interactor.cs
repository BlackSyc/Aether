using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using System.Linq;
using System;

public class Interactor : MonoBehaviour
{
    public readonly struct Events
    {
        public static event Action<Interactable, Interactor> OnProposedInteraction;
        public static event Action OnCancelProposedInteraction;
        public static event Action OnInteract;

        public static void ProposedInteraction(Interactable interactable, Interactor interactor)
        {
            OnProposedInteraction?.Invoke(interactable, interactor);
        }

        public static void CancelProposedInteraction()
        {
            OnCancelProposedInteraction?.Invoke();
        }

        public static void Interact()
        {
            OnInteract?.Invoke();
        }
    }
    
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
            Events.CancelProposedInteraction();
        }
    }

    public void Interact(CallbackContext context)
    {
        if (context.performed)
        {
            currentInteractable?.Interact(with: this);
            Events.Interact();
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
            currentInteractable.ProposeInteraction(with: this);
            Events.ProposedInteraction(currentInteractable, this);
        }
        else
        {
            currentInteractable = null;
            Events.CancelProposedInteraction();
        }
    }

    private void Update()
    {
        if(IsActive)
            CheckForInteractables();
    }
}
