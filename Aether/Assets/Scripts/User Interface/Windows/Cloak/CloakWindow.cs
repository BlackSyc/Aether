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
    private TextMeshProUGUI header;

    [SerializeField]
    private TextMeshProUGUI keywords;

    [SerializeField]
    private TextMeshProUGUI content;

    [SerializeField]
    private GameObject window;

    private CloakInfo currentCloakInfo;

    private void Start()
    {
        AetherEvents.GameEvents.CloakEvents.OnShowCloakInfo += ShowCloakInfo;
        AetherEvents.GameEvents.CloakEvents.OnHideCloakInfo += CloseWindow;
    }

    private void ShowCloakInfo(CloakInfo cloakInfo)
    {
        currentCloakInfo = cloakInfo;

        header.text = cloakInfo.Name;
        header.color = cloakInfo.Colour;
        keywords.text = cloakInfo.Keywords;
        content.text = cloakInfo.Description;

        actionMapManager.EnablePopUpActionMap();
        AetherEvents.UIEvents.ToolTips.HideAll();
        window.SetActive(true);
    }

    public void EquipCloak()
    {
        AetherEvents.GameEvents.CloakEvents.EquipCloak(currentCloakInfo.CloakPrefab);
        CloseWindow();
    }

    private void CloseWindow()
    {
        window.SetActive(false);
        AetherEvents.UIEvents.ToolTips.UnhideAll();
        actionMapManager.EnablePlayerActionMap();
    }

    public void CloseWindow(CallbackContext context)
    {
        if (!context.performed)
            return;

        currentCloakInfo = null;
        CloseWindow();
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.CloakEvents.OnShowCloakInfo -= ShowCloakInfo;
        AetherEvents.GameEvents.CloakEvents.OnHideCloakInfo -= CloseWindow;
    }
}
