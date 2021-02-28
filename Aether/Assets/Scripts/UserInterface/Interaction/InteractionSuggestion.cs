using Aether.Core;
using Aether.Input;
using Syc.Core.Interaction;
using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Interaction
{
    public class InteractionSuggestion : MonoBehaviour, ILocalPlayerLink
    {
        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField]
        private Animator animator;

        private void Awake()
        {
            Player.LinkToLocalPlayer(this);
        }

        private void Start()
        {
            InputSystem.OnActionMapSwitched += InputSystem_OnActionMapSwitched;
        }

        private void InputSystem_OnActionMapSwitched(ActionMap newActionMap)
        {
            gameObject.SetActive(newActionMap == ActionMap.Player);
        }

        private void Activate(Interactable interactable)
        {
            text.text = interactable.InteractionMessage;
            animator.SetBool("Performed", false);
            animator.SetBool("Shown", true);
        }

        private void Deactivate()
        {
            animator.SetBool("Shown", false);
        }

        private void PerformAnimation()
        {
            animator.SetBool("Performed", true);
            animator.SetBool("Shown", false);
        }

        private void OnDestroy()
        {
            InputSystem.OnActionMapSwitched -= InputSystem_OnActionMapSwitched;
            Player.UnlinkFromLocalPlayer(this);
        }

        public void OnLocalPlayerLinked(Player player)
        {
            if (!player.Has(out Interactor interactor))
                return;

            interactor.OnInteracted += PerformAnimation;
            interactor.OnInteractionProposed += Activate;
            interactor.OnProposedInteractionCancelled += Deactivate;
        }

        public void OnLocalPlayerUnlinked(Player player)
        {
            if (!player.Has(out Interactor interactor))
                return;

            interactor.OnInteracted -= PerformAnimation;
            interactor.OnInteractionProposed -= Activate;
            interactor.OnProposedInteractionCancelled -= Deactivate;
        }
    }
}
