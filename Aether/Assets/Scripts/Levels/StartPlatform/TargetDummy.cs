﻿using System.Collections;
using Syc.Combat;
using Syc.Combat.HealthSystem;
using Syc.Combat.SpellSystem;
using Syc.Combat.SpellSystem.ScriptableObjects;
using UnityEngine;

namespace Aether.StartPlatform
{
    [RequireComponent(typeof(ICombatSystem))]
    public class TargetDummy : MonoBehaviour
    {
        [SerializeField]
        private float tickDelay = 1f;

        [SerializeField]
        private SpellBehaviour healingSpell;

        private ICombatSystem combatSystem;

        private HealthSystem health;

        private CastingSystem spellSystem;

        private void Start()
        {
            combatSystem = GetComponent<ICombatSystem>();
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
                    spellSystem.CastSpell(new Spell(healingSpell));
                }
                yield return new WaitForSeconds(tickDelay);
            }

            Destroy(gameObject);
        }
    }
}
