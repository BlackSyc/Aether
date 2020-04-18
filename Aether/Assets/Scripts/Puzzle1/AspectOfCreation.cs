using Aether.SpellSystem.ScriptableObjects;
using ScriptableObjects;
using System;
using UnityEngine;

public class AspectOfCreation : MonoBehaviour
{
    public struct Events
    {
        public static event Action OnDialogComplete;

        public static void CompleteDialog()
        {
            OnDialogComplete?.Invoke();
        }
    }


    [SerializeField]
    private Dialog dialog = null;


    [SerializeField]
    private Spell reward = null;

    private void Start()
    {
        Puzzle1_Manager.Events.OnStage1Completed += ActivateAspect;
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
        Events.CompleteDialog();
        Destroy(this.gameObject);
    }

    private void GrantArcaneMissile()
    {
        Hint.Get("Cursor").Activate();
        Player.Instance.SpellSystem.AddSpell(0, reward);
    }

    private void OnDestroy()
    {
        Puzzle1_Manager.Events.OnStage1Completed -= ActivateAspect;
        dialog.GetDialogLine("Never mind").OnComplete -= GrantArcaneMissile;
        dialog.OnComplete -= AspectOfCreationDialogComplete;
    }
}
