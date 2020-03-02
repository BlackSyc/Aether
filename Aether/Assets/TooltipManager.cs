using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    private static TooltipManager _instance;

    [SerializeField]
    private GameObject interactionTooltip;

    private void Awake()
    {
        _instance = this;
    }

    public static void ShowInteractionTooltip()
    {
        _instance.interactionTooltip.SetActive(true);
    }

    public static void HideInteractionTooltip()
    {
        _instance.interactionTooltip.SetActive(false);
    }
}
