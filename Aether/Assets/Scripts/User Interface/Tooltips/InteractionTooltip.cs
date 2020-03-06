using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionTooltip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Animator animator;

    private void Start()
    {
        AetherEvents.GameEvents.Interaction.ShowInteraction += Activate;
        AetherEvents.GameEvents.Interaction.HideInteraction += Deactivate;
        AetherEvents.GameEvents.Interaction.Interact += PerformAnimation;

        AetherEvents.UIEvents.ToolTips.HideAll += Hide;
        AetherEvents.UIEvents.ToolTips.UnhideAll += Unhide;
    }

    private void Activate(string message)
    {
        text.text = message;
        animator.SetBool("Shown", true);
    }

    private void Deactivate()
    {
        animator.SetBool("Shown", false);
    }

    private void PerformAnimation()
    {
        animator.SetTrigger("Performed");
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
        AetherEvents.GameEvents.Interaction.ShowInteraction -= Activate;
        AetherEvents.GameEvents.Interaction.HideInteraction -= Deactivate;
        AetherEvents.GameEvents.Interaction.Interact -= PerformAnimation;

        AetherEvents.UIEvents.ToolTips.HideAll -= Hide;
        AetherEvents.UIEvents.ToolTips.UnhideAll -= Unhide;
    }
}
