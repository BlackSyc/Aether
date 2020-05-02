using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether.SpellSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Projectile : SpellObject
    {
        [SerializeField]
        private float movementSpeed = 20;

        [SerializeField]
        private float rotationSpeed = 500;

        [SerializeField]
        private float maxLifeTime = 10;

        private bool travelling = false;

        private float despawnTime;

        private void OnCollisionEnter(Collision collision)
        {
            if (!travelling)
                return;

            if (Layers.ObstructionLayer.Contains(collision.gameObject))
            {
                travelling = false;
                OnObstructionHit(collision.gameObject);
            }

            if (collision.transform == Target.TargetTransform)
            {
                travelling = false;
                OnTargetHit(collision.gameObject);
            }
        }

        public abstract void OnObstructionHit(GameObject obstructionObject);

        public abstract void OnTargetHit(GameObject targetObject);

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

            transform.Translate(new Vector3(0, 0, movementSpeed * Time.fixedDeltaTime), Space.Self);

            Quaternion desiredRotation = Quaternion.LookRotation(Target.Position - transform.position, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
