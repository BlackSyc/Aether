using UnityEngine;
using System.Linq;
using System;
using static Aether.Input.InputSystem;
using Aether.Core.Interaction;

namespace Aether.Interaction
{
    public class Interactor : MonoBehaviour, IInteractor
    {
        public readonly struct Events
        {
            public static event Action<IInteractable, IInteractor> OnProposedInteraction;
            public static event Action OnCancelProposedInteraction;
            public static event Action OnInteract;

            public static void ProposedInteraction(IInteractable interactable, IInteractor interactor)
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
            Events.Interact();
        }

        public void CheckForInteractables()
        {
            Interactable interactable = Physics.OverlapSphere(this.transform.position, interactionRadius, layers)
                .Select(x => x.GetComponent<Interactable>())
                .Where(x => x != null)
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
            CheckForInteractables();
        }
    }
}
