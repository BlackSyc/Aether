using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeystoneInfoPanel : MonoBehaviour
{
    [SerializeField]
    private Image _sprite;

    [SerializeField]
    private TextMeshProUGUI _nameText;

    [SerializeField]
    private TextMeshProUGUI _descriptionText;

    [SerializeField]
    private RectTransform _labelPanel;

    [SerializeField]
    private GameObject _labelPrefab;

    [SerializeField]
    private TextMeshProUGUI _activateButtonText;

    private Keystone _keystone;

    private void Start()
    {
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneActivated += KeystoneActivated;
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneDeactivated += KeystoneDeactivated;
    }

    private void KeystoneDeactivated(Keystone keystone)
    {
        if (keystone != _keystone)
            return;

        _activateButtonText.text = "Activate";
    }

    private void KeystoneActivated(Keystone keystone)
    {
        if (keystone != _keystone)
            return;

        _activateButtonText.text = "Deactivate";
    }
    public void SetInfo(Keystone keystone)
    {
        CleanPanel();

        _keystone = keystone;
        
        _nameText.text = _keystone.Name;

        _keystone.Labels.ForEach(x =>
        {
            GameObject label = GameObject.Instantiate(_labelPrefab, _labelPanel);
            label.GetComponent<KeystoneLabel>().SetText(x);
        });

        _descriptionText.text = _keystone.Description;

        _sprite.sprite = _keystone.Sprite ? _keystone.Sprite : null;

        _activateButtonText.text = _keystone.State.IsActivated ? "Deactivate" : "Activate";
    }

    private void CleanPanel()
    {
        foreach (Transform label in _labelPanel)
        {
            Destroy(label.gameObject);
        }
    }

    public void ToggleActivateKeystone()
    {
        AetherEvents.GameEvents.AttunementEvents.ToggleAttunement(_keystone);
    }
}
