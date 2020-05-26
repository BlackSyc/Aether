using System;
using UnityEngine;


namespace Aether.Core.Dialog.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Dialog/DialogLine")]
    public class DialogLine : ScriptableObject
    {
        public string Name;

        public string Speaker;
        public string Content;

        public event Action OnComplete;

        public void Complete()
        {
            if (OnComplete == null)
                return;

            OnComplete();
        }
    }
}
