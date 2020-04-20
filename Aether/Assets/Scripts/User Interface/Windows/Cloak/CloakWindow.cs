using Aether.InputSystem;
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
        CloakProvider.Events.OnInteract += ShowCloakWindow;
        AetherEvents.UIEvents.Windows.OnClosePopups += ClosePopup;
    }

    private void ShowCloakWindow(CloakProvider cloakProvider)
    {
        header.text = cloakProvider.Cloak.Name;
        keywords.text = cloakProvider.Cloak.Keywords;
        content.text = cloakProvider.Cloak.Description;

        if (!cloakProvider.Cloak.IsEquipped)
        {
            equipButton.onClick.AddListener(() => {
                cloakProvider.Equip();
                CloseWindow();
            });
            equipButtonText.text = "Equip";
        }
        else
        {
            equipButton.onClick.AddListener(() => {
                cloakProvider.Unequip();
                CloseWindow();
            });
            equipButtonText.text = "Unequip";
        }

        InputSystem.SwitchToActionMap(ActionMap.PopUp);
        window.SetActive(true);
    }

    private void CloseWindow()
    {
        equipButton.onClick.RemoveAllListeners();
        window.SetActive(false);
        AetherEvents.UIEvents.ToolTips.UnhideAll();
        InputSystem.SwitchToActionMap(ActionMap.Player);
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
