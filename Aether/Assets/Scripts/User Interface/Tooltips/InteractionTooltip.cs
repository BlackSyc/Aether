using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static AetherEvents;

public class InteractionTooltip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Animator animator;

    private void Start()
    {
        Interactor.Events.OnProposedInteraction += Activate;
        Interactor.Events.OnCancelProposedInteraction += Deactivate;
        Interactor.Events.OnInteract += PerformAnimation;

        AetherEvents.UIEvents.ToolTips.OnHideAll += Hide;
        AetherEvents.UIEvents.ToolTips.OnUnhideAll += Unhide;
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

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Unhide()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Interactor.Events.OnProposedInteraction -= Activate;
        Interactor.Events.OnCancelProposedInteraction -= Deactivate;
        Interactor.Events.OnInteract -= PerformAnimation;

        AetherEvents.UIEvents.ToolTips.OnHideAll -= Hide;
        AetherEvents.UIEvents.ToolTips.OnUnhideAll -= Unhide;
    }
}
