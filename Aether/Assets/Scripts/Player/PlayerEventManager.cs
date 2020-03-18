using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    [SerializeField]
    private Interactor interactor;

    [SerializeField]
    private GameObject modelObject;

    [SerializeField]
    private CharacterController characterController;

    private void Start()
    {
        AetherEvents.GameEvents.PlayerEvents.OnSetPlayerPosition += SetPosition;
        AetherEvents.GameEvents.PlayerEvents.OnActivateInteractor += ActivateInteractor;
        AetherEvents.GameEvents.PlayerEvents.OnShowModel += ShowModel;
    }

    private void ShowModel(bool flag)
    {
        modelObject.SetActive(flag);
    }

    private void ActivateInteractor(bool flag)
    {
        interactor.IsActive = flag;

        if (!flag)
            interactor.CancelCurrentlyProposedInteraction();
    }

    private void SetPosition(Vector3 newPosition)
    {
        characterController.Move(newPosition - transform.position);
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.PlayerEvents.OnSetPlayerPosition -= SetPosition;
        AetherEvents.GameEvents.PlayerEvents.OnActivateInteractor -= ActivateInteractor;
        AetherEvents.GameEvents.PlayerEvents.OnShowModel -= ShowModel;
    }
}
