using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class AttunementWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject _attunementWindow;

    [SerializeField]
    private RectTransform _keystoneButtonParent;

    [SerializeField]
    private GameObject _keystoneButtonPrefab;

    [SerializeField]
    private KeystoneInfoPanel _infoPanel;

    [SerializeField]
    private ScrollRect _scrollRect;


    // Start is called before the first frame update
    void Start()
    {
        AetherEvents.GameEvents.AttunementEvents.OnOpenAttunementWindow += OpenWindow;
        AetherEvents.UIEvents.Windows.OnClosePopups += CloseWindow;
    }

    private void OpenWindow(List<Keystone> keystones)
    {
        _attunementWindow.SetActive(true);

        bool selectionMade = false;

        foreach(Keystone keystone in keystones)
        {
            GameObject keystoneSelectorObject = GameObject.Instantiate(_keystoneButtonPrefab, _keystoneButtonParent);
            KeystoneSelector keystoneSelector = keystoneSelectorObject.GetComponent<KeystoneSelector>();
            keystoneSelector.SetKeystone(keystone);
            keystoneSelector.OnSelect = () => ShowInfo(keystone);
            keystoneSelector.OnScroll = Scroll;

            if (!selectionMade)
            {
                selectionMade = true;
                keystoneSelector.Select();
            }
        }
        
        AetherEvents.GameEvents.InputSystemEvents.EnablePopupActionMap();
        AetherEvents.UIEvents.ToolTips.HideAll();
    }

    private void ShowInfo(Keystone keystone)
    {
        _infoPanel.SetInfo(keystone);
    }

    private void Scroll(PointerEventData pointerEventData)
    {
        _scrollRect.OnScroll(pointerEventData);
    }

    public void CloseWindow()
    {
        if (_attunementWindow.activeSelf)
        {
            _attunementWindow.SetActive(false);
            foreach(Transform child in _keystoneButtonParent)
            {
                Destroy(child.gameObject);
            }

            AetherEvents.GameEvents.InputSystemEvents.EnablePlayerActionMap();
            AetherEvents.UIEvents.ToolTips.UnhideAll();
        }
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.AttunementEvents.OnOpenAttunementWindow -= OpenWindow;
        AetherEvents.UIEvents.Windows.OnClosePopups -= CloseWindow;
    }
}
