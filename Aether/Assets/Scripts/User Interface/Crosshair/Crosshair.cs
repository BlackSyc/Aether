using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private TargetManager _targetManager;

    [SerializeField]
    private RectTransform _targetLock;

    [SerializeField]
    private GameObject _targetTracker;

    [SerializeField]
    private Animator _crosshairAnimator;

    [SerializeField]
    private GameObject _crosshairContainer;

    [SerializeField]
    private Camera _camera;

    private void Start()
    {
        _crosshairAnimator.keepAnimatorControllerStateOnDisable = true;
        SpellSystem.Events.OnSpellAdded += UpdateCrosshairState;
        SpellSystem.Events.OnSpellRemoved += UpdateCrosshairState;
        AetherEvents.UIEvents.Crosshair.OnHideCrosshair += HideCrosshair;
        AetherEvents.UIEvents.Crosshair.OnUnhideCrosshair += UnhideCrosshair;
    }

    private void UnhideCrosshair()
    {
        _crosshairContainer.SetActive(true);
    }

    private void HideCrosshair()
    {
        _crosshairContainer.SetActive(false);
    }

    private void UpdateCrosshairState(Spell spell)
    {
        _crosshairContainer.SetActive(Player.Instance.SpellSystem.HasSpells);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(_targetManager.GetCurrentTarget().HasTargetTransform)
        {
            if (_targetManager.HasLockedTarget && _targetManager.GetCurrentTarget().TargetTransform == _targetManager.Target.TargetTransform)
            {
                _crosshairAnimator.SetBool("HasObjectTarget", false);
            }
            else
            {
                _crosshairAnimator.SetBool("HasObjectTarget", true);
            }
        }
        else
        {
            _crosshairAnimator.SetBool("HasObjectTarget", false);
        }

        if (_targetManager.HasLockedTarget)
        {
            _targetTracker.SetActive(true);
            _targetTracker.GetComponent<RectTransform>().position = _camera.WorldToScreenPoint(_targetManager.Target.Position);
        }
        else
        {
            _targetTracker.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        SpellSystem.Events.OnSpellAdded -= UpdateCrosshairState;
        SpellSystem.Events.OnSpellRemoved -= UpdateCrosshairState;
        AetherEvents.UIEvents.Crosshair.OnHideCrosshair -= HideCrosshair;
        AetherEvents.UIEvents.Crosshair.OnUnhideCrosshair -= UnhideCrosshair;
    }
}
