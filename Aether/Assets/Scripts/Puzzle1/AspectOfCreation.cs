﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectOfCreation : MonoBehaviour
{
    [SerializeField]
    private Puzzle1_Manager puzzleManager;

    [SerializeField]
    private Dialog dialog;


    [SerializeField]
    private Spell reward;

    private Interactor interactor;

    private void Start()
    {
        dialog.GetDialogLine("Never mind").OnComplete += GrantArcaneMissile;
        dialog.OnComplete += puzzleManager.StartStage2;
    }

    public void Interact(Interactor interactor, Interactable interactable)
    {
        this.interactor = interactor;
        interactable.IsActive = false;

        AetherEvents.GameEvents.DialogEvents.StartDialog(dialog);
    }

    private void GrantArcaneMissile()
    {
        interactor.transform.parent.GetComponent<SpellSystem>().SpellSlot1.SelectSpell(reward);
    }

    private void OnDestroy()
    {
        dialog.GetDialogLine("Never mind").OnComplete -= GrantArcaneMissile;
        dialog.OnComplete -= puzzleManager.StartStage2;
    }
}
