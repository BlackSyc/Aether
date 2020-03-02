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
            // ADD: animate tooltip
        }
    }

    public void CheckForInteractables()
    {
        Collider[] interactables = Physics.OverlapSphere(this.transform.position, interactionRadius, layers);
        if (interactables.Length > 0)
        {
            currentInteractable = interactables[0].GetComponent<Interactable>();
            TooltipManager.ShowInteractionTooltip();
        }
        else
        {
            currentInteractable = null;
            TooltipManager.HideInteractionTooltip();
        }
    }

    private void Update()
    {
        CheckForInteractables();
    }
}
