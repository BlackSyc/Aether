using Aether.Core.UserInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour, IUserInterface
{
    [SerializeField]
    private RectTransform windowContainer;

    [SerializeField]
    private RectTransform tooltipContainer;

    public RectTransform GetContainer(UIContainer containerType)
    {
        switch (containerType)
        {
            case UIContainer.WindowContainer:
                return windowContainer;
            case UIContainer.TooltipContainer:
                return tooltipContainer;
            default:
                return null;
        }
    }
}
