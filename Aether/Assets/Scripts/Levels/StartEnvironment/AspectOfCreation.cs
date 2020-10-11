using System;
using Aether.Core;
using Aether.Core.Dialog.ScriptableObjects;
using Aether.Core.Tutorial;
using Aether.Input;
using Syc.Combat;
using Syc.Combat.SpellSystem;
using Syc.Combat.SpellSystem.ScriptableObjects;
using Syc.Core.Interaction;
using UnityEngine;

namespace Aether.Levels.StartEnvironment
{
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
        private Dialog dialog;

        [SerializeField]
        private Spell reward;

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
            GetComponent<Collider>().enabled = true;
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
            Hints.Get("Cursor").Activate();
            if (Player.Instance.Has(out ICombatSystem combatSystem)
                && combatSystem.Has(out SpellRack spellRack))
            {
                spellRack.AddSpell(reward, 0);
            }
            InputSystem.SwitchToActionMap(ActionMap.UserInterface);
        }

        private void OnDestroy()
        {
            Puzzle1_Manager.Events.OnStage1Completed -= ActivateAspect;
            dialog.GetDialogLine("Never mind").OnComplete -= GrantArcaneMissile;
            dialog.OnComplete -= AspectOfCreationDialogComplete;
        }
    }
}
