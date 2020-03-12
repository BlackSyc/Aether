using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using System.Linq;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private float interactionRadius = 1;

    [SerializeField]
    private LayerMask layers;

    private Interactable currentInteractable;

    public void Interact(CallbackContext context)
    {
        if (context.performed)
        {
            currentInteractable?.Interact(with: this);
            AetherEvents.GameEvents.InteractionEvents.Interact();
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
            AetherEvents.GameEvents.InteractionEvents.ProposeInteraction(currentInteractable, this);
        }
        else
        {
            currentInteractable = null;
            AetherEvents.GameEvents.InteractionEvents.CancelProposeInteraction();
        }
    }

    private void Update()
    {
        CheckForInteractables();
    }
}
