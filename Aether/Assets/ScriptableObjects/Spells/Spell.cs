using Aether.Core.Combat;
using Aether.ScriptableObjects.Modifiers;
using System;
using UnityEngine;


namespace Aether.ScriptableObjects.Spells
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Spell System/Spell")]
    [Serializable]
    public class Spell : ScriptableObject, ISpell
    {
        #region Serialized fields
        [SerializeField]
        private string name;

        [SerializeField]
        private Aspect aspect;

        [SerializeField]
        private bool onlyCastOnSelf;

        [TextArea(0,10)]
        [SerializeField]
        private string description;

        [SerializeField]
        private float healthDelta;

        [SerializeField]
        private int globalAggro;

        [SerializeField]
        private int localAggro;

        [SerializeField]
        private float castDuration;

        [SerializeField]
        private float coolDown;

        [SerializeField]
        private bool castWhileMoving;

        [SerializeField]
        private LayerMask layerMask;

        [SerializeField]
        private GameObject spellPrefab;
        #endregion

        #region Accessors
        public string Name => name;
        public Aspect Aspect => aspect;
        public bool OnlyCastOnSelf => onlyCastOnSelf;
        public string Description => description;
        public float HealthDelta => healthDelta;
        public int GlobalAggro => globalAggro;
        public int LocalAggro => localAggro;
        public float CastDuration => castDuration;
        public float CoolDown => coolDown;
        public bool CastWhileMoving => castWhileMoving;
        public LayerMask LayerMask => layerMask;
        public GameObject SpellPrefab => spellPrefab;
        #endregion
    }
}
