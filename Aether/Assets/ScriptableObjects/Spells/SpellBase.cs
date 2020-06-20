using Aether.Core.Combat;
using UnityEngine;

namespace Aether.ScriptableObjects.Spells
{
    public abstract class SpellBase : ScriptableObject, ISpell
    {
        #region Serialized fields
        [SerializeField]
        private string name;

        [SerializeField]
        private Aspect aspect;

        [SerializeField]
        private bool onlyCastOnSelf;

        [TextArea(0, 10)]
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
        private bool onGlobalCooldown = true;

        [SerializeField]
        private bool castWhileMoving;

        [SerializeField]
        private bool requiresCombatTarget;

        [SerializeField]
        private LayerMask layerMask;
        #endregion

        #region Accessors
        public string Name => name;
        public Aspect Aspect => aspect;
        public bool OnlyCastOnSelf => onlyCastOnSelf;
        public string Description => string.Format(description, name, aspect, onlyCastOnSelf, healthDelta, globalAggro, localAggro, castDuration, coolDown, castWhileMoving, layerMask);
        public float HealthDelta => healthDelta;
        public int GlobalAggro => globalAggro;
        public int LocalAggro => localAggro;
        public float CastDuration => castDuration;
        public float CoolDown => coolDown;
        public bool CastWhileMoving => castWhileMoving;
        public bool RequiresCombatTarget => requiresCombatTarget;
        public LayerMask LayerMask => layerMask;
        public bool OnGlobalCooldown => onGlobalCooldown;
        #endregion

        public abstract void Initialize(ISpellCast spellCast);
    }
}
