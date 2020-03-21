﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectOfCreation : MonoBehaviour
{

    [SerializeField]
    private Dialog dialog = null;


    [SerializeField]
    private Spell reward = null;

    private void Start()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage1 += ActivateAspect;
        dialog.GetDialogLine("Never mind").OnComplete += GrantArcaneMissile;
        dialog.OnComplete += AspectOfCreationDialogComplete;
    }

    public void Interact(Interactor interactor, Interactable interactable)
    {
        interactable.IsActive = false;
        dialog.Start();
    }

    private void ActivateAspect()
    {
        GetComponent<Interactable>().IsActive = true;

        // To do: Spawn Aspect model
        // Instantiate(this.aspectPrefab, this.transform);
    }

    private void AspectOfCreationDialogComplete()
    {
        AetherEvents.GameEvents.Puzzle1Events.AspectOfCreationDialogComplete();
        Destroy(this.gameObject);
    }

    private void GrantArcaneMissile()
    {
        Player.Instance.SpellSystem.AddSpell(reward);
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage1 -= ActivateAspect;
        dialog.GetDialogLine("Never mind").OnComplete -= GrantArcaneMissile;
        dialog.OnComplete -= AspectOfCreationDialogComplete;
    }
}
