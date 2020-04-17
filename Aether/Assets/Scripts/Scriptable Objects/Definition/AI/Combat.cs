using Aether.Spells;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/AI/Combat")]
    public class Combat : AIState
    {
        [SerializeField]
        private int minimumAggro;

        [SerializeField]
        private AIState lowAggroState;

        public override void Create(AIStateMachine stateMachine)
        {
            if (stateMachine.GetComponent<SpellSystem>())
            {
                stateMachine.TransitionTo(lowAggroState);
                return;
            }
        }

        private void Attack(AIStateMachine stateMachine, AggroTrigger enemy)
        {
            AggroTable ownAggroTable = stateMachine.GetComponent<AggroTable>();
            SpellSystem ownSpellSystem = stateMachine.GetComponent<SpellSystem>();
            Health enemyHealth = enemy.GetComponent<Health>();

            if (!enemyHealth || enemyHealth.IsDead)
            {
                enemy.IsActive = false;
                ownAggroTable.RemoveAggroTrigger(enemy);
                stateMachine.TransitionTo(lowAggroState);
                return;
            }

            if (!ownSpellSystem.IsCasting)
                ownSpellSystem.CastSpell(0);

            stateMachine.transform.LookAt(enemy.transform);
        }

        public override void UpdateState(AIStateMachine stateMachine)
        {
            AggroTable aggroTable = stateMachine.GetComponent<AggroTable>();
            SpellSystem spellSystem = stateMachine.GetComponent<SpellSystem>();
            Health health = stateMachine.GetComponent<Health>();

            if (spellSystem && aggroTable && health)
            {
                if (health.IsDead)
                {
                    Destroy(stateMachine.gameObject);
                    return;
                }

                if (aggroTable.GetHighestAggroTrigger().aggro >= minimumAggro)
                    Attack(stateMachine, aggroTable.GetHighestAggroTrigger().trigger);
                else
                    stateMachine.TransitionTo(lowAggroState);
            }
        }
    }
}
