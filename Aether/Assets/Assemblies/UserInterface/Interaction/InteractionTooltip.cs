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
            Events.OnProposedInteraction += Activate;
            Interactor.Events.OnCancelProposedInteraction += Deactivate;
            Interactor.Events.OnInteract += PerformAnimation;

            InputSystem.OnActionMapSwitched += InputSystem_OnActionMapSwitched;
        }

        private void InputSystem_OnActionMapSwitched(ActionMap newActionMap)
        {
            gameObject.SetActive(newActionMap == ActionMap.Player);
        }

        private void Activate(Interactable interactable, Interactor _)
        {
            text.text = interactable.ProposeInteractionMessage;
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
            Interactor.Events.OnProposedInteraction -= Activate;
            Interactor.Events.OnCancelProposedInteraction -= Deactivate;
            Interactor.Events.OnInteract -= PerformAnimation;

            InputSystem.OnActionMapSwitched -= InputSystem_OnActionMapSwitched;
        }
    }
}
