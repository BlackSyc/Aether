using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Interaction : UnityEvent<Interactor, Interactable>{}

public class Interactable : MonoBehaviour
{
    public string TooltipText = "to interact";

    public Interaction interaction;

    public void Interact(Interactor with)
    {
        Debug.Log("interacted");
        interaction.Invoke(with, this);
    }
}
