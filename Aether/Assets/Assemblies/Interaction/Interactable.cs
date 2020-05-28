using Aether.Core.Interaction;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Aether.Interaction
{
    [Serializable]
    internal class Interaction : UnityEvent<Interactor, Interactable> { }

    [Serializable]
    internal class InteractionProposition : UnityEvent<Interactor, Interactable> { }

    [RequireComponent(typeof(Collider))]
    internal class Interactable : MonoBehaviour, IInteractable
    {

        public Interaction Interaction;
        public InteractionProposition InteractionProposition;

        public bool IsActive { get; set; } = true;

        public string InteractionMessage { get; set; } = "to interact";

        public void Interact(Interactor with)
        {
            Interaction.Invoke(with, this);
        }

        public void ProposeInteraction(Interactor with)
        {
            InteractionProposition.Invoke(with, this);
        }
    }
}
