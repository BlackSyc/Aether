using Syc.Combat.SpellSystem;
using UnityEngine;

namespace Aether.Combat.SpellObjects
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleBurst : SpellObject
    {
        private ParticleSystem _particleSystem;
        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _particleSystem.Play();
            Destroy(gameObject, _particleSystem.main.duration);
        }
        
    }
}
