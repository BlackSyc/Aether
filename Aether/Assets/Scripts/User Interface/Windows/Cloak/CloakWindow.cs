using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class CloakWindow : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI header;

    [SerializeField]
    private TextMeshProUGUI keywords;

    [SerializeField]
    private TextMeshProUGUI content;

    [SerializeField]
    private Button equipButton;

    [SerializeField]
    private TextMeshProUGUI equipButtonText;

    [SerializeField]
    private GameObject window;

    private CloakInfo currentCloakInfo;

    private void Start()
    {
        AetherEvents.GameEvents.CloakEvents.OnShowCloakInfo += ShowCloakInfo;
        AetherEvents.GameEvents.CloakEvents.OnHideCloakInfo += CloseWindow;
        AetherEvents.UIEvents.Windows.OnClosePopups += ClosePopup;
    }

    private void ShowCloakInfo(CloakInfo cloakInfo)
    {
        currentCloakInfo = cloakInfo;

        header.text = cloakInfo.Name;
        header.color = cloakInfo.Colour;
        keywords.text = cloakInfo.Keywords;
        content.text = cloakInfo.Description;

        if (!currentCloakInfo.IsEquipped)
        {
            equipButton.onClick.AddListener(() => EquipCloak());
            equipButtonText.text = "Equip";
        }
        else
        {
            equipButton.onClick.AddListener(() => UnequipCloak());
            equipButtonText.text = "Unequip";
        }

        AetherEvents.GameEvents.InputSystemEvents.EnablePopupActionMap();
        AetherEvents.UIEvents.ToolTips.HideAll();
        window.SetActive(true);
    }

    public void EquipCloak()
    {
        AetherEvents.GameEvents.CloakEvents.EquipCloak(currentCloakInfo);
        CloseWindow();
    }

    public void UnequipCloak()
    {
        AetherEvents.GameEvents.CloakEvents.UnequipCloak();
        CloseWindow();
    }

    private void CloseWindow()
    {
        equipButton.onClick.RemoveAllListeners();
        window.SetActive(false);
        AetherEvents.UIEvents.ToolTips.UnhideAll();
        AetherEvents.GameEvents.InputSystemEvents.EnablePlayerActionMap();
    }

    public void ClosePopup()
    {
        currentCloakInfo = null;
        if(window.activeSelf)
            CloseWindow();
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.CloakEvents.OnShowCloakInfo -= ShowCloakInfo;
        AetherEvents.GameEvents.CloakEvents.OnHideCloakInfo -= CloseWindow;
        AetherEvents.UIEvents.Windows.OnClosePopups -= ClosePopup;
    }
}
