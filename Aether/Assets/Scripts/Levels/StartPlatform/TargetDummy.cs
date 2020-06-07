using Aether.Core.Combat;
using Aether.ScriptableObjects.Spells;
using System.Collections;
using UnityEngine;

namespace Aether.StartPlatform
{
    [RequireComponent(typeof(ICombatSystem))]
    public class TargetDummy : MonoBehaviour
    {
        [SerializeField]
        private float tickDelay = 1f;

        [SerializeField]
        private Spell healingSpell;

        private ICombatSystem combatSystem;

        private IHealth health;

        private ISpellSystem spellSystem;

        private void Start()
        {
            combatSystem = GetComponent<ICombatSystem>();
            spellSystem = combatSystem.Get<ISpellSystem>();

            spellSystem.AddSpell(0, healingSpell);
            health = combatSystem.Get<IHealth>();

            StartCoroutine(HealWhenLow());
        }

        private IEnumerator HealWhenLow()
        {
            while (!health.IsDead)
            {
                if (health.CurrentHealth <= 900)
                {
                    spellSystem.CastSpell(0, new Target(combatSystem));
                }
                yield return new WaitForSeconds(tickDelay);
            }

            Destroy(gameObject);
        }
    }
}
