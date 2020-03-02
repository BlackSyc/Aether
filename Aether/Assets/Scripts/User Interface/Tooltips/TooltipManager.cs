using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    private static TooltipManager _instance;

    [SerializeField]
    private InteractionTooltip interactionTooltip;

    private void Awake()
    {
        _instance = this;
    }

    public static InteractionTooltip GetInteractionTooltip()
    {
        return _instance.interactionTooltip;
    }
}
