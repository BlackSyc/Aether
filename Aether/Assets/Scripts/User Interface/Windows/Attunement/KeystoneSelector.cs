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
    private Color _selectedColour;

    [SerializeField]
    private Color _hoverColour;

    private Color _defaultColour;

    public Action OnSelect;

    public Action<PointerEventData> OnScroll;

    [SerializeField]
    private TextMeshProUGUI _buttonLabel;

    private bool _selected = false;

    public void SetKeystone(Keystone keystone)
    {
        _keystone = keystone;
        _buttonLabel.text = keystone.Name;
    }

    public void Select()
    {
        GameObject.FindObjectsOfType<KeystoneSelector>().ToList().ForEach(x => x.Deselect());
        _background.color = _selectedColour;
        _selected = true;
        OnSelect?.Invoke();
    }

    public void Deselect()
    {
        _background.color = _defaultColour;
        _selected = false;
    }

    public void Scroll(BaseEventData pointerEventData)
    {
        OnScroll?.Invoke((PointerEventData) pointerEventData);
    }

    public void Hover()
    {
        if(!_selected)
            _background.color = _hoverColour;
    }

    public void Unhover()
    {
        if(!_selected)
            _background.color = _defaultColour;
    }
}
