using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CloakWindow : MonoBehaviour
{
    [SerializeField]
    private ActionMapManager actionMapManager;

    [SerializeField]
    private TooltipManager tooltipManager;

    [SerializeField]
    private TextMeshProUGUI header;

    [SerializeField]
    private TextMeshProUGUI keywords;

    [SerializeField]
    private TextMeshProUGUI content;

    [SerializeField]
    private GameObject window;

    [SerializeField]
    private string dreamHeader;

    [SerializeField]
    private Color dreamColour;

    [SerializeField]
    private string dreamKeywords;

    [TextArea]
    [SerializeField]
    private string dreamContent;

    [SerializeField]
    private string nightmareHeader;

    [SerializeField]
    private Color nightmareColour;

    [SerializeField]
    private string nightmareKeywords;

    [TextArea]
    [SerializeField]
    private string nightmareContent;

    [SerializeField]
    private string illusionHeader;

    [SerializeField]
    private Color illusionColour;

    [SerializeField]
    private string illusionKeywords;

    [TextArea]
    [SerializeField]
    private string illusionContent;



    public void ShowDream()
    {
        header.text = dreamHeader;
        header.color = dreamColour;
        keywords.text = dreamKeywords;
        content.text = dreamContent;

        actionMapManager.EnablePopUpActionMap();
        tooltipManager.HideAllToolTips();
        window.SetActive(true);
    }

    public void ShowNightmare()
    {
        header.text = nightmareHeader;
        header.color = nightmareColour;
        keywords.text = nightmareKeywords;
        content.text = nightmareContent;

        actionMapManager.EnablePopUpActionMap();
        tooltipManager.HideAllToolTips();
        window.SetActive(true);
    }

    public void ShowIllusion()
    {
        header.text = illusionHeader;
        header.color = illusionColour;
        keywords.text = illusionKeywords;
        content.text = illusionContent;

        actionMapManager.EnablePopUpActionMap();
        tooltipManager.HideAllToolTips();
        window.SetActive(true);
    }

    public void CloseWindow()
    {
        window.SetActive(false);
        tooltipManager.UnHideAllToolTips();
        actionMapManager.EnablePlayerActionMap();
    }

    public void CloseWindow(CallbackContext context)
    {
        if (!context.performed)
            return;

        window.SetActive(false);
        tooltipManager.UnHideAllToolTips();
        actionMapManager.EnablePlayerActionMap();
    }
}
