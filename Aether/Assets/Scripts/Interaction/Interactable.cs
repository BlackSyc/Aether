using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Interaction : UnityEvent<Interactor, Interactable>{}

[Serializable]
public class InteractionProposition : UnityEvent<Interactor, Interactable> { }

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    public string ProposeInteractionMessage = "to interact";

    public Interaction Interaction;
    public InteractionProposition InteractionProposition;

    public bool IsActive = true;

    public void Interact(Interactor with)
    {
        Interaction.Invoke(with, this);
    }

    public void ProposeInteraction(Interactor with)
    {
        InteractionProposition.Invoke(with, this);
    }
}
