using System;

namespace Aether.Core.Interaction
{
    public static class Events
    {
        public static event Action OnInteracted;

        public static event Action<IInteractable, IInteractor> OnInteractionProposed;

        public static event Action OnProposedInteractionCancelled;

        public static void Interacted()
        {
            OnInteracted?.Invoke();
        }

        public static void InteractionProposed(IInteractable interactable, IInteractor interactor)
        {
            OnInteractionProposed?.Invoke(interactable, interactor);
        }

        public static void ProposedInteractionCancelled()
        {
            OnProposedInteractionCancelled?.Invoke();
        }
    }
}
