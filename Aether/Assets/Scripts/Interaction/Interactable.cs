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

    public Interaction Interaction;

    public bool IsActive = true;

    public void Interact(Interactor with)
    {
        Interaction.Invoke(with, this);
    }
}
