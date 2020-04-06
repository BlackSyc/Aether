﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static AetherEvents;

public class AttunementWindow : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]
    private GameObject attunementWindow;

    [SerializeField]
    private RectTransform keystoneSelectorParent;

    [SerializeField]
    private ScrollRect keystoneSelectorScrollRect;

    [SerializeField]
    private GameObject keystoneSelectorPrefab;

    [SerializeField]
    private KeystoneInfoPanel keystoneInfoPanel;
    #endregion

    #region MonoBehaviour
    void Start()
    {
        AttunementDevice.Events.OnInteract += OpenWindow;
        UIEvents.Windows.OnClosePopups += CloseWindow;
    }

    private void OnDestroy()
    {
        AttunementDevice.Events.OnInteract -= OpenWindow;
        UIEvents.Windows.OnClosePopups -= CloseWindow;
    }
    #endregion

    #region EventHandlers
    private void OpenWindow(AttunementDevice attunementDevice)
    {
        attunementWindow.SetActive(true);

        bool selectionMade = false;

        attunementDevice.Keystones.ForEach(keystone =>
        {
            GameObject keystoneSelectorObject = GameObject.Instantiate(keystoneSelectorPrefab, keystoneSelectorParent);
            KeystoneSelector keystoneSelector = keystoneSelectorObject.GetComponent<KeystoneSelector>();
            keystoneSelector.SetKeystone(keystone);
            keystoneSelector.OnSelect = () => keystoneInfoPanel.Show(keystone, attunementDevice);
            keystoneSelector.OnScroll = Scroll;

            if (!selectionMade)
            {
                selectionMade = true;
                keystoneSelector.Select();
            }
        });

        attunementDevice.NewKeystones.ForEach(newKeystone =>
        {
            GameObject keystoneSelectorObject = GameObject.Instantiate(keystoneSelectorPrefab, keystoneSelectorParent);
            KeystoneSelector keystoneSelector = keystoneSelectorObject.GetComponent<KeystoneSelector>();
            keystoneSelector.SetKeystone(newKeystone);
            keystoneSelector.OnSelect = () => keystoneInfoPanel.Show(newKeystone, attunementDevice);
            keystoneSelector.OnScroll = Scroll;
            keystoneSelector.PlayNewlyAddedAnimation();

            if (!selectionMade)
            {
                selectionMade = true;
                keystoneSelector.Select();
            }
        });

        attunementDevice.ApplyNewKeystones();

        AetherEvents.GameEvents.InputSystemEvents.EnablePopupActionMap();
        AetherEvents.UIEvents.ToolTips.HideAll();
        AetherEvents.UIEvents.Crosshair.HideCrosshair();

    }

    private void CloseWindow()
    {
        if (attunementWindow.activeSelf)
        {
            attunementWindow.SetActive(false);

            foreach (Transform child in keystoneSelectorParent)
            {
                Destroy(child.gameObject);
            }

            AetherEvents.GameEvents.InputSystemEvents.EnablePlayerActionMap();
            AetherEvents.UIEvents.ToolTips.UnhideAll();
            AetherEvents.UIEvents.Crosshair.UnhideCrosshair();
        }
    }
    #endregion

    #region Private Methods
    private void Scroll(PointerEventData pointerEventData)
    {
        keystoneSelectorScrollRect.OnScroll(pointerEventData);
    }
    #endregion
}
