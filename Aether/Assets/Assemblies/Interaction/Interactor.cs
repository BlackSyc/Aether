using UnityEngine;
using System.Linq;
using Aether.Core.Interaction;
using Aether.Core;

namespace Aether.Interaction
{
    public class Interactor : CoreSystemBehaviour, IInteractor
    {
        public GameObject Player => transform.parent.gameObject;

        [SerializeField]
        private float interactionRadius = 1;

        [SerializeField]
        private LayerMask layers;

        private Interactable currentInteractable;

        private void Start()
        {
            Input.InputSystem.InputActions.Player.Interact.performed += _ => Interact();
        }

        private void OnDisable()
        {
            Input.InputSystem.InputActions.Player.Interact.performed -= _ => Interact();
        }


        public void Interact()
        {
            currentInteractable?.Interact(with: this);
            Events.Interacted();
        }

        public void CheckForInteractables()
        {
            Interactable interactable = Physics.OverlapSphere(this.transform.position, interactionRadius, layers)
                .Select(x => x.GetComponent<Interactable>())
                .Where(x => x != null)
                .FirstOrDefault(x => x.IsActive);

            if (interactable != null)
            {
                ProposeInteraction(interactable);
            }
            else
            {
                CancelProposedInteraction();
            }
        }

        private void ProposeInteraction(Interactable interactable)
        {
            currentInteractable = interactable;
            currentInteractable.ProposeInteraction(with: this);
            Events.InteractionProposed(currentInteractable, this);
        }

        private void CancelProposedInteraction()
        {
            currentInteractable = null;
            Events.ProposedInterctionCancelled();
        }

        private void Update()
        {
            CheckForInteractables();
        }
    }
}
