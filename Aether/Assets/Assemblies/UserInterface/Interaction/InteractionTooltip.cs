using Aether.Core.Interaction;
using Aether.Input;
using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Interaction
{
    public class InteractionTooltip : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField]
        private Animator animator;

        private void Start()
        {
            Events.OnInteractionProposed += Activate;
            Events.OnProposedInteractionCancelled += Deactivate;
            Events.OnInteracted += PerformAnimation;

            InputSystem.OnActionMapSwitched += InputSystem_OnActionMapSwitched;
        }

        private void InputSystem_OnActionMapSwitched(ActionMap newActionMap)
        {
            gameObject.SetActive(newActionMap == ActionMap.Player);
        }

        private void Activate(IInteractable interactable, IInteractor _)
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
        }

        private void OnDestroy()
        {
            Events.OnInteractionProposed -= Activate;
            Events.OnProposedInteractionCancelled -= Deactivate;
            Events.OnInteracted -= PerformAnimation;

            InputSystem.OnActionMapSwitched -= InputSystem_OnActionMapSwitched;
        }
    }
}
