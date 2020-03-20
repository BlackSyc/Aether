using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

public class KeystoneSelector : MonoBehaviour
{
    private Keystone _keystone;

    [SerializeField]
    private Image _background;

    [SerializeField]
    private Color _selectedBackgroundColour;

    [SerializeField]
    private Color _hoverBackgroundColour;

    [SerializeField]
    private Color _activatedTextColour;

    [SerializeField]
    private Color _defaultBackgroundColour;

    [SerializeField]
    private Color _defaultTextColour;

    public Action OnSelect;

    public Action<PointerEventData> OnScroll;

    [SerializeField]
    private TextMeshProUGUI _buttonLabel;

    private bool _selected = false;

    private void Start()
    {
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneActivated += KeystoneActivated;
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneDeactivated += KeystoneDeactivated;
    }

    private void KeystoneActivated(Keystone keystone)
    {
        if (keystone != _keystone)
            return;

        _buttonLabel.color = _activatedTextColour;
        _buttonLabel.fontStyle = FontStyles.Bold;
    }

    private void KeystoneDeactivated(Keystone keystone)
    {
        if (keystone != _keystone)
            return;

        _buttonLabel.color = _defaultTextColour;
        _buttonLabel.fontStyle = FontStyles.Normal;
    }

    public void SetKeystone(Keystone keystone)
    {
        _keystone = keystone;
        _buttonLabel.text = _keystone.Name;
        _buttonLabel.color = _keystone.State.IsActivated ? _activatedTextColour : _defaultTextColour;
        _buttonLabel.fontStyle = _keystone.State.IsActivated ? FontStyles.Bold : FontStyles.Normal;
    }

    public void Select()
    {
        GameObject.FindObjectsOfType<KeystoneSelector>().ToList().ForEach(x => x.Deselect());
        _background.color = _selectedBackgroundColour;
        _selected = true;
        OnSelect?.Invoke();
    }

    public void Deselect()
    {
        _background.color = _defaultBackgroundColour;
        _selected = false;
    }

    public void Scroll(BaseEventData pointerEventData)
    {
        OnScroll?.Invoke((PointerEventData) pointerEventData);
    }

    public void Hover()
    {
        if(!_selected)
            _background.color = _hoverBackgroundColour;
    }

    public void Unhover()
    {
        if(!_selected)
            _background.color = _defaultBackgroundColour;
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneActivated -= KeystoneActivated;
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneDeactivated -= KeystoneDeactivated;
    }
}
