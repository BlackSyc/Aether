using System.Collections;
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

    public void Interact(Interactor interactor, Interactable interactable)
    {
        this.interactor = interactor;
        interactable.IsActive = false;
        dialog.Line("Never mind")?.OnComplete(() => GrantArcaneMissile());
        dialog.OnComplete(() => puzzleManager.StartStage2());
        dialog.Start();
    }

    private void GrantArcaneMissile()
    {
        interactor.transform.parent.GetComponent<SpellSystem>().Missile.SetSpell(reward);
        Debug.Log("Player has received the ability to cast Arcane Missile!");
    }
}
