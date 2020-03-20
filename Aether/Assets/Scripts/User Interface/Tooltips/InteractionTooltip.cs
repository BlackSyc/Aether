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
        InteractionEvents.OnProposeInteraction += Activate;
        InteractionEvents.OnCancelProposeInteraction += Deactivate;
        InteractionEvents.OnInteract += PerformAnimation;

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
        InteractionEvents.OnProposeInteraction -= Activate;
       InteractionEvents.OnCancelProposeInteraction -= Deactivate;
       InteractionEvents.OnInteract -= PerformAnimation;

        AetherEvents.UIEvents.ToolTips.OnHideAll -= Hide;
        AetherEvents.UIEvents.ToolTips.OnUnhideAll -= Unhide;
    }
}
