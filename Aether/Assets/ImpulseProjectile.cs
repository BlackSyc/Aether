using Cinemachine;
using Syc.Combat.SpellSystem;
using Syc.Combat.SpellSystem.SpellObjects;
using UnityEngine;

namespace Aether
{
    public class ImpulseProjectile : Projectile
    {

        private CinemachineImpulseSource _impulseSource;
        
        // Start is called before the first frame update
        public override void Initialize()
        {
            _impulseSource = GetComponent<CinemachineImpulseSource>();
            SpellCast.OnSpellCompleted += TriggerImpulse;
            base.Initialize();
        }

        private void TriggerImpulse(SpellCast obj)
        {
            _impulseSource.GenerateImpulse(Camera.main.transform.forward);
            SpellCast.OnSpellCompleted -= TriggerImpulse;
        }
    }
}
