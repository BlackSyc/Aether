using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        CloakObject.Events.OnInteract += ShowCloakWindow;
        AetherEvents.UIEvents.Windows.OnClosePopups += ClosePopup;
    }

    private void ShowCloakWindow(CloakObject cloakObject)
    {
        header.text = cloakObject.Cloak.Name;
        keywords.text = cloakObject.Cloak.Keywords;
        content.text = cloakObject.Cloak.Description;

        if (!cloakObject.Cloak.IsEquipped)
        {
            equipButton.onClick.AddListener(() => {
                cloakObject.Equip();
                CloseWindow();
            });
            equipButtonText.text = "Equip";
        }
        else
        {
            equipButton.onClick.AddListener(() => {
                cloakObject.Unequip();
                CloseWindow();
            });
            equipButtonText.text = "Unequip";
        }

        AetherEvents.GameEvents.InputSystemEvents.EnablePopupActionMap();
        AetherEvents.UIEvents.ToolTips.HideAll();
        AetherEvents.UIEvents.Crosshair.HideCrosshair();
        window.SetActive(true);
    }

    private void CloseWindow()
    {
        equipButton.onClick.RemoveAllListeners();
        window.SetActive(false);
        AetherEvents.UIEvents.Crosshair.UnhideCrosshair();
        AetherEvents.UIEvents.ToolTips.UnhideAll();
        AetherEvents.GameEvents.InputSystemEvents.EnablePlayerActionMap();
    }

    public void ClosePopup()
    {
        if(window.activeSelf)
            CloseWindow();
    }

    private void OnDestroy()
    {
        AetherEvents.UIEvents.Windows.OnClosePopups -= ClosePopup;
    }
}
