using Aether.Core.Combat;
using System;
using System.Collections;
using UnityEngine;

namespace Aether.ScriptableObjects.Modifiers
{
    [Serializable]
    public abstract class ModifierType : ScriptableObject, IModifierType
    {
        #region Serialized fields
        [SerializeField]
        private string name;

        [SerializeField]
        private float duration;

        [SerializeField]
        private string description;

        [SerializeField]
        private Sprite icon;
        #endregion

        #region Accessors
        public string Name => name;
        public float Duration => duration;
        public string Description => description;
        public Sprite Icon => icon;
        #endregion

        #region Methods
        public abstract IEnumerator modifierCoroutine(ICombatSystem combatSystem);

        public virtual void Abort(ICombatSystem combatSystem) { }
        #endregion
    }
}
