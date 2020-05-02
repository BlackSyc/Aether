using Aether.SpellSystem;
using Aether.TargetSystem;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/AI/Combat")]
    public class Combat : AIState
    {

        [SerializeField]
        private AIState lowAggroState;

        private ITargetSystem targetSystem;

        private ISpellSystem spellSystem;

        private Health healthSystem;

        public override void Create(AIStateMachine stateMachine)
        {
            targetSystem = stateMachine.GetComponent<ITargetSystem>();
            spellSystem = stateMachine.GetComponent<ISpellSystem>();
            healthSystem = stateMachine.GetComponent<Health>();
        }

        private void Attack(AIStateMachine stateMachine, AggroTrigger enemy)
        {
            AggroTable ownAggroTable = stateMachine.GetComponent<AggroTable>();
            ISpellSystem ownSpellSystem = stateMachine.GetComponent<ISpellSystem>();
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
            if (targetSystem != null && spellSystem != null && healthSystem != null)
            {
                if (healthSystem.IsDead)
                {
                    Destroy(stateMachine.gameObject);
                    return;
                }

                if (spellSystem.IsCasting)
                    return;


                if (targetSystem.GetCurrentTarget(stateMachine.gameObject.EnemyLayer()) != null)
                    spellSystem.CastSpell(0);
                else
                    stateMachine.TransitionTo(lowAggroState);
            }
        }
    }
}
