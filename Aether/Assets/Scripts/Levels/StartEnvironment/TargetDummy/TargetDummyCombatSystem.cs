using Aether.Core.Attributes;
using Syc.Combat;
using Syc.Combat.HealthSystem;
using Syc.Combat.SpellSystem;
using Syc.Combat.SpellSystem.ScriptableObjects;
using UnityEngine;

namespace Aether.Levels.StartEnvironment.TargetDummy
{
    public class TargetDummyCombatSystem : CombatMonoSystem
    {
        public DummySpawner Spawner { get; set; }
        
        public override bool CanBeTargeted
        {
            get => !healthSystem.IsDead && enabled;
            set => enabled = value;
        }
        
        public override object Allegiance => gameObject.layer;
        
        public override ICombatAttributes AttributeSystem => attributes;

        public override Transform Origin => transform;
        
        [SerializeField] private ScryerAttributes attributes;

        [SerializeField] private HealthSystem healthSystem;

        [SerializeField] private CastingSystem castingSystem;

        [SerializeField] private Spell healingSpell;

        private bool _isHealing;
        private bool _shouldBeHealing;

        private void Awake()
        {
            AddSubsystem(healthSystem);
            AddSubsystem(castingSystem);
            
            healthSystem.OnHealthChanged += CheckIfShouldHeal;
            healthSystem.OnDied += Died;
            castingSystem.OnNewSpellCast += NewSpellCastStarted;
        }

        private void Died(DamageRequest _)
        {
            Spawner.SpawnNewDummy();
            Destroy(gameObject);
        }

        private void NewSpellCastStarted(SpellCast newSpellCast)
        {
            newSpellCast.OnSpellCompleted += CastCompleted;
            _isHealing = true;
        }

        private void CastCompleted(SpellCast completedCast)
        {
            completedCast.OnSpellCompleted -= CastCompleted;
            _isHealing = false;
        }

        private void CheckIfShouldHeal(float newHealth)
        {
            _shouldBeHealing = newHealth < healthSystem.MaxHealth;
        }

        private void FixedUpdate()
        {
            if (!_isHealing && _shouldBeHealing)
                castingSystem.CastSpell(new SpellState(healingSpell));
            
            if(transform.position.y < -100)
                Died(null);
        }

        private void OnDestroy()
        {
            healthSystem.OnHealthChanged -= CheckIfShouldHeal;
            castingSystem.OnNewSpellCast -= NewSpellCastStarted;
        }
    }
}
