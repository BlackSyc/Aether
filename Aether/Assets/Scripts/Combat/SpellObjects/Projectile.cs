using System.Collections;
using Syc.Combat.SpellSystem;
using Syc.Combat.SpellSystem.ScriptableObjects.SpellEffects;
using Syc.Combat.TargetSystem;
using UnityEngine;

namespace Aether.Combat.SpellObjects
{
    public class Projectile : SpellObject
    {
        [SerializeField] private float movementSpeed = 10;

        [SerializeField] private float rotationSpeed = 10;

        [SerializeField] private float rotationSpeedFactor = 1;

        [SerializeField] private float maxLifeTime = 10.0f;

        #region MonoBehaviour
        private void Start()
        {
            SpellCast.OnSpellCompleted += FlyToTarget;
            SpellCast.OnSpellCancelled += DestroyGameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject != Target.TargetObject)
                return;
            
            Spell.ExecuteAll(SpellEffectType.OnImpact, Source, new Target(Target.TargetObject, transform.position), SpellCast, this);
            DestroyGameObject(null);
        }
        
        private void OnDestroy()
        {
            SpellCast.OnSpellCompleted -= FlyToTarget;
            SpellCast.OnSpellCancelled -= DestroyGameObject;
        }
        
        #endregion

        private void DestroyGameObject(SpellCast _)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }

        private void FlyToTarget(SpellCast _)
        {
            transform.SetParent(null, true);
            StartCoroutine(FlyToTargetCoroutine());
        }

        private IEnumerator FlyToTargetCoroutine()
        {
            var currentLifeTime = 0f;
            while (maxLifeTime > currentLifeTime)
            {
                currentLifeTime += Time.deltaTime;

                rotationSpeed += Time.deltaTime * rotationSpeedFactor;
                
                var ownTransform = transform;
                var position = ownTransform.position;
                var positionDelta = Target.TargetObject.transform.position - position;
                
                var desiredLookRotation =  Quaternion.LookRotation(positionDelta);
                ownTransform.rotation = Quaternion.RotateTowards(ownTransform.rotation, desiredLookRotation, rotationSpeed * Time.deltaTime);
                position += ownTransform.forward * (Time.deltaTime * movementSpeed);
                ownTransform.position = position;
                yield return null;
            }
        }

    }
}
