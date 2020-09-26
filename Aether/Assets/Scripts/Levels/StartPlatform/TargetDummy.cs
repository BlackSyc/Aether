using System.Collections;
using Syc.Combat;
using Syc.Combat.HealthSystem;
using Syc.Combat.SpellSystem;
using Syc.Combat.SpellSystem.ScriptableObjects;
using UnityEngine;

namespace Aether.Levels.StartPlatform
{
    [RequireComponent(typeof(ICombatSystem))]
    public class TargetDummy : MonoBehaviour
    {
        [SerializeField]
        private float tickDelay = 1f;

        [SerializeField]
        private Spell healingSpell;

        private ICombatSystem combatSystem;

        private HealthSystem health;

        private CastingSystem spellSystem;

        private void Start()
        {
            combatSystem = GetComponent<ICombatSystem>();
            
            if (combatSystem == default)
                return;

            spellSystem = combatSystem.Get<CastingSystem>();
            
            health = combatSystem.Get<HealthSystem>();

            StartCoroutine(HealWhenLow());
        }

        private IEnumerator HealWhenLow()
        {
            while (!health.IsDead)
            {
                if (health.CurrentHealth <= 900)
                {
                    spellSystem.CastSpell(new SpellState(healingSpell));
                }
                yield return new WaitForSeconds(tickDelay);
            }

            Destroy(gameObject);
        }
    }
}
