using Aether.Core.Combat;
using Aether.Core.Combat.Extensions;
using UnityEngine;

namespace Aether.Combat.SpellSystem.SpellBehaviours
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Projectile : SpellBehaviour
    {
        [SerializeField]
        private float movementSpeed = 20;

        [SerializeField]
        private float rotationSpeed = 500;

        [SerializeField]
        private float maxLifeTime = 10;

        protected Vector3 targetOffset;

        private bool travelling = false;

        private float despawnTime;

        private void OnCollisionEnter(Collision collision)
        {
            if (!travelling)
                return;

            if (collision.gameObject.IsTarget(out var target))
            {
                OnTargetHit(target);
            }
            
            OnObstructionHit(collision.gameObject);
        }

        public override void SetTarget(Core.Combat.ICombatSystem newTarget)
        {
            base.SetTarget(newTarget);

            if (Caster.Has(out ITargetSystem targetSystem))
                targetOffset = targetSystem.GetCurrentTargetExact(Spell.LayerMask) - newTarget.Transform.Position;
            else
                targetOffset = Vector3.zero;
        }

        public override void CastStarted()
        {
            throw new System.NotImplementedException();
        }

        public abstract void OnTargetHit(Core.Combat.ICombatSystem target);

        public abstract void OnObstructionHit(GameObject obstructionObject);

        public override void CastFired()
        {
            transform.SetParent(null, true);
            travelling = true;
            despawnTime = Time.time + maxLifeTime;
        }

        public void FixedUpdate()
        {
            if (!travelling)
                return;

            if (despawnTime < Time.time)
                Destroy(this.gameObject);

            Vector3 destination = Target.Transform.Position + targetOffset;

            transform.Translate(new Vector3(0, 0, movementSpeed * Time.fixedDeltaTime), Space.Self);

            Quaternion desiredRotation = Quaternion.LookRotation(destination - transform.position, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
