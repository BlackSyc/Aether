using Aether.Core;
using Aether.Core.Combat;
using Aether.Core.Combat.Extensions;
using Aether.Core.Extensions;
using System;
using UnityEngine;

namespace Aether.ScriptableObjects.Spells.Behaviours
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class ProjectileBehaviour : SpellBehaviour
    {
        [SerializeField]
        private float movementSpeed = 20;

        [SerializeField]
        private float rotationSpeed = 500;

        [SerializeField]
        private float maxLifeTime = 10;

        private bool travelling = false;

        private float despawnTime;

        #region SpellBehaviour
        protected override void CastStarted(ISpellCast spellCast)
        {
            GetComponent<Animator>().SetFloat("CastTime", 1 / spellCast.Spell.CastDuration);
            GetComponent<Animator>().SetTrigger("CastStarted");
        }

        protected override void CastProgress(float progress)
        {
            GetComponent<Animator>().SetFloat("CastTime", progress);
        }

        protected override void CastCompleted(ISpellCast spellCast)
        {
            GetComponent<Animator>().SetTrigger("CastFired");

            transform.SetParent(null, true);
            travelling = true;
            despawnTime = Time.time + maxLifeTime;
        }

        #endregion

        #region Projectile
        public abstract void OnTargetHit(ICombatSystem target);

        public abstract void OnObstructionHit(GameObject obstructionObject);
        #endregion

        #region MonoBehaviour
        private void OnCollisionEnter(Collision collision)
        {
            if (!travelling)
                return;

            if (collision.gameObject.HasCombatSystem(out ICombatSystem combatSystem) && spellCast.Target.HasCombatTarget(out ICombatSystem target))
            {
                if (combatSystem == target)
                    OnTargetHit(combatSystem);

                return;
            }

            if (Layers.ObstructionLayer.Contains(collision.gameObject))
                OnObstructionHit(collision.gameObject);
        }

        public void FixedUpdate()
        {
            if (!travelling)
                return;

            if (despawnTime < Time.time)
                Destroy(this.gameObject);

            transform.Translate(new Vector3(0, 0, movementSpeed * Time.fixedDeltaTime), Space.Self);

            Quaternion desiredRotation;

            if (spellCast.Target.HasCombatTarget(out ICombatSystem combatTarget))
                desiredRotation = Quaternion.LookRotation((combatTarget.Transform.Position + spellCast.Target.RelativeHitPoint) - transform.position, transform.up);
            else
                desiredRotation = Quaternion.LookRotation(spellCast.Target.RelativeHitPoint - transform.position, transform.up);


            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.fixedDeltaTime);
        }
        #endregion
    }
}
