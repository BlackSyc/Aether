using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

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
            TooltipManager.GetInteractionTooltip().PerformAnimation();
        }
    }

    public void CheckForInteractables()
    {
        Collider[] interactables = Physics.OverlapSphere(this.transform.position, interactionRadius, layers);
        if (interactables.Length > 0)
        {
            currentInteractable = interactables[0].GetComponent<Interactable>();
            TooltipManager.GetInteractionTooltip().Activate(currentInteractable.TooltipText);
        }
        else
        {
            currentInteractable = null;
            TooltipManager.GetInteractionTooltip().Deactivate();
        }
    }

    private void Update()
    {
        CheckForInteractables();
    }
}
