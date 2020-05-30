using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


namespace Aether.Core.Dialog.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Dialog/Dialog")]
    public class Dialog : ScriptableObject
    {
        public readonly struct Events
        {
            public static event Action<Dialog> OnStartDialog;

            public static void StartDialog(Dialog dialog)
            {
                OnStartDialog?.Invoke(dialog);
            }
        }

        public List<DialogLine> dialogLines;

        public event Action OnComplete;

        public DialogLine GetDialogLine(string name)
        {
            return dialogLines.FirstOrDefault(x => x.Name.Equals(name));
        }

        public void Complete()
        {
            if (OnComplete == null)
                return;

            OnComplete();
        }

        public void Start()
        {
            Events.StartDialog(this);
        }
    }
}
