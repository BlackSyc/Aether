using Aether.Core;
using Aether.Core.Interaction;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using InputSystem = Aether.Input.InputSystem;

namespace Aether.Interaction
{
    public class Interactor : CoreSystemBehaviour, IInteractor
    {
        public GameObject Player => transform.parent.gameObject;

        [SerializeField]
        private float interactionRadius = 1;

        [SerializeField]
        private LayerMask layers;

        [SerializeField]
        private bool isPlayer = false;

        public bool IsPlayer => isPlayer;

        private Interactable currentInteractable;

        private void Start()
        {
            InputSystem.InputActions.Player.Interact.performed += Interact;
        }

        private void OnDisable()
        {
            InputSystem.InputActions.Player.Interact.performed -= Interact;
        }


        public void Interact(InputAction.CallbackContext _)
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
            Events.ProposedInteractionCancelled();
        }

        private void Update()
        {
            CheckForInteractables();
        }
    }
}
