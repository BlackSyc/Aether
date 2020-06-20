using Aether.Core;
using Aether.Core.Combat;
using Aether.Core.Dialog.ScriptableObjects;
using Aether.Core.Interaction;
using Aether.Core.Tutorial;
using Aether.Input;
using Aether.ScriptableObjects.Spells;
using System;
using UnityEngine;

namespace Aether.StartPlatform
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
        private Dialog dialog = null;


        [SerializeField]
        private ObjectSpell reward = null;

        private void Start()
        {
            Puzzle1_Manager.Events.OnStage1Completed += ActivateAspect;
            dialog.GetDialogLine("Never mind").OnComplete += GrantArcaneMissile;
            dialog.OnComplete += AspectOfCreationDialogComplete;
        }

        public void Interact(IInteractor interactor, IInteractable interactable)
        {
            interactable.IsActive = false;
            dialog.Start();
        }

        private void ActivateAspect()
        {
            GetComponent<IInteractable>().IsActive = true;

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
            Player.Instance.Get<ICombatSystem>().Get<ISpellSystem>().AddSpell(0, reward);
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
