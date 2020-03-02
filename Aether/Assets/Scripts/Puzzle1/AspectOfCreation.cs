using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectOfCreation : MonoBehaviour
{
    [SerializeField]
    private Puzzle1_Manager puzzleManager;

    private List<string> dialog = new List<string>() { 
        "Greetings, Scryer.", 
        "We didn't expect you here so soon...", 
        "The others haven't even completed the-",
        "-Never mind... Let's get you going.", 
        "Take this. Just... Don't upset the others..." };

    public void Interact(Interactor interactor, Interactable interactable)
    {
        interactable.IsActive = false;
        DialogCallback callBack = WindowManager.GetDialogWindow().StartDialog(dialog);
        callBack.DialogComplete.AddListener(() => Despawn());
    }

    public void Despawn()
    {
        puzzleManager.StartStage2();
    }
}
