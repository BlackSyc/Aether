using System;
using Aether.Core.Attributes;
using Syc.Combat;
using Syc.Combat.HealthSystem;
using UnityEngine;

namespace Aether.Combat.TargetDummy
{
    public class TargetDummyCombatSystem : CombatMonoSystem
    {
        public override bool CanBeTargeted
        {
            get => !healthSystem.IsDead && enabled;
            set => enabled = value;
        }
        
        public override object Allegiance => gameObject.layer;
        
        public override ICombatAttributes AttributeSystem => attributes;

        public override Transform Origin => transform;

        [SerializeField]
        private HealthSystem healthSystem;

        [SerializeField] private ScryerAttributes attributes;

        private void Awake()
        {
            AddSubsystem(healthSystem);
        }
    }
}
