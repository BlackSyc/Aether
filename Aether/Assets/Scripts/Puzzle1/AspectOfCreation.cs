using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectOfCreation : MonoBehaviour
{
    private List<string> dialog = new List<string>() { 
        "Greetings, Scryer.", 
        "We didn't expect you here so soon...", 
        "The others haven't even completed the-",
        "-Never mind... Let's get you going.", 
        "Take this. Just... Don't upset the others..." };

    public void Interact(Interactor interactor, Interactable interactable)
    {
        interactable.IsActive = false;
        WindowManager.GetDialogWindow().StartDialog(dialog);
    }
}
