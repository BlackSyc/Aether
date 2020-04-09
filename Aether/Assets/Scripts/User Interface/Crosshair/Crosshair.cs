using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private PlayerTargetManager _targetManager;

    [SerializeField]
    private RectTransform targetTracker;

    [SerializeField]
    private Animator _crosshairAnimator;

    [SerializeField]
    private GameObject _crosshairContainer;

    [SerializeField]
    private Vector3 defaultTooltipOffset;

    [SerializeField]
    private Camera _camera;

    private void Start()
    {
        _crosshairAnimator.keepAnimatorControllerStateOnDisable = true;
        AspectOfCreation.Events.OnDialogComplete += UpdateCrosshairState;
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

    private void UpdateCrosshairState()
    {
        _crosshairContainer.SetActive(Player.Instance.SpellSystem.HasActiveSpells);
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
            targetTracker.gameObject.SetActive(true);
            ShowTargetTrackerOn(_targetManager.Target);
        }
        else
        {
            targetTracker.gameObject.SetActive(false);
        }
    }

    private void ShowTargetTrackerOn(Target target)
    {
        if (!target.HasTargetTransform)
        {
            targetTracker.position = _camera.WorldToScreenPoint(target.Position + defaultTooltipOffset);
        }

        else if (target.TargetTransform.GetComponent<TooltipOffset>() != null)
        {
            targetTracker.position = _camera.WorldToScreenPoint(target.Position + target.TargetTransform.GetComponent<TooltipOffset>().Offset);
        }
        else
        {
            targetTracker.position = _camera.WorldToScreenPoint(target.Position + defaultTooltipOffset);
        }

        targetTracker.gameObject.SetActive(targetTracker.GetComponent<RectTransform>().position.z > 0);
    }

    private void OnDestroy()
    {
        AspectOfCreation.Events.OnDialogComplete -= UpdateCrosshairState;
        AetherEvents.UIEvents.Crosshair.OnHideCrosshair -= HideCrosshair;
        AetherEvents.UIEvents.Crosshair.OnUnhideCrosshair -= UnhideCrosshair;
    }
}
