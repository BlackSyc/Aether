using Aether.InputSystem;
using Aether.SpellSystem;
using Aether.TargetSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private GameObject targetTrackerPrefab;

    [SerializeField]
    private Animator _crosshairAnimator;

    [SerializeField]
    private GameObject _crosshairContainer;

    [SerializeField]
    private Vector3 defaultTrackerOffset;

    [SerializeField]
    private Camera _camera;

    private void Start()
    {
        _crosshairAnimator.keepAnimatorControllerStateOnDisable = true;
        _crosshairContainer.SetActive(false);
        InputSystem.OnActionMapSwitched += InputSystem_OnActionMapSwitched;
        Player.Instance.SpellSystem.OnSpellIsCast += CreateTargetTracker;
    }

    private void OnDestroy()
    {
        InputSystem.OnActionMapSwitched -= InputSystem_OnActionMapSwitched;
        Player.Instance.SpellSystem.OnSpellIsCast -= CreateTargetTracker;
    }

    private void InputSystem_OnActionMapSwitched(ActionMap newActionMap)
    {
        _crosshairContainer.SetActive(newActionMap == ActionMap.Player && Player.Instance.SpellSystem.HasActiveSpells);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        LayerMask layerMask = Player.Instance.SpellSystem.GetCombinedLayerMask();

        if (Player.Instance.TargetManager.GetCurrentTarget(layerMask) != null)
        {
            _crosshairAnimator.SetBool("HasObjectTarget", true);
        }
        else
        {
            _crosshairAnimator.SetBool("HasObjectTarget", false);
        }
    }

    private void CreateTargetTracker(SpellCast spellCast)
    {
        GameObject targetTrackerObject = Instantiate(targetTrackerPrefab, transform);
        TargetTracker targetTracker = targetTrackerObject.GetComponent<TargetTracker>();
        targetTracker.SpellCast = spellCast;
        targetTracker.Offset = defaultTrackerOffset;
        targetTracker.Camera = _camera;
    }
}
