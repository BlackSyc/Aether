using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public enum Role
{
    Dream, Nightmare, Illusion, Corruption
}
public class CloakWindow : MonoBehaviour
{
    [SerializeField]
    private ActionMapManager actionMapManager;

    [SerializeField]
    private Shoulder shoulder;

    [SerializeField]
    private TextMeshProUGUI header;

    [SerializeField]
    private TextMeshProUGUI keywords;

    [SerializeField]
    private TextMeshProUGUI content;

    [SerializeField]
    private GameObject window;

    private Role role;

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
        role = Role.Dream;
        header.text = dreamHeader;
        header.color = dreamColour;
        keywords.text = dreamKeywords;
        content.text = dreamContent;

        actionMapManager.EnablePopUpActionMap();
        AetherEvents.UIEvents.ToolTips.HideAll();
        window.SetActive(true);
    }

    public void ShowNightmare()
    {
        role = Role.Nightmare;
        header.text = nightmareHeader;
        header.color = nightmareColour;
        keywords.text = nightmareKeywords;
        content.text = nightmareContent;

        actionMapManager.EnablePopUpActionMap();
        AetherEvents.UIEvents.ToolTips.HideAll();
        window.SetActive(true);
    }

    public void ShowIllusion()
    {
        role = Role.Illusion;
        header.text = illusionHeader;
        header.color = illusionColour;
        keywords.text = illusionKeywords;
        content.text = illusionContent;

        actionMapManager.EnablePopUpActionMap();
        AetherEvents.UIEvents.ToolTips.HideAll();
        window.SetActive(true);
    }

    public void EquipCloak()
    {
        switch (role)
        {
            case Role.Dream:
                shoulder.EquipDreamCloak();
                break;
            case Role.Nightmare:
                shoulder.EquipNightmareCloak();
                break;
            case Role.Illusion:
                shoulder.EquipIllusionCloak();
                break;
        }
        CloseWindow();
    }

    public void CloseWindow()
    {
        window.SetActive(false);
        AetherEvents.UIEvents.ToolTips.UnhideAll();
        actionMapManager.EnablePlayerActionMap();
    }

    public void CloseWindow(CallbackContext context)
    {
        if (!context.performed)
            return;

        window.SetActive(false);
        AetherEvents.UIEvents.ToolTips.UnhideAll();
        actionMapManager.EnablePlayerActionMap();
    }
}
