using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectOfCreation : MonoBehaviour
{
    [SerializeField]
    private Puzzle1_Manager puzzleManager;

    [SerializeField]
    private Dialog dialog;

    public void Interact(Interactor interactor, Interactable interactable)
    {
        interactable.IsActive = false;
        dialog.Line("Never mind")?.OnComplete(() => GrantArcaneMissile());
        dialog.OnComplete(() => puzzleManager.StartStage2());
        dialog.Start();
    }

    private void GrantArcaneMissile()
    {
        //ADD: call to add Arcane Missile to the player
        Debug.Log("Player has received the ability to cast Arcane Missile!");
    }
}
