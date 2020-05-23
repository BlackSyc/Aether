using Aether.TargetSystem;
using UnityEngine;

namespace Aether.SpellSystem
{
    public class NightmareMissile : ArcaneMissile
    {

        public override void OnTargetHit(ITarget target)
        {
            ExecuteTargetHitBehaviour(target);

            PlayMissileHitAnimation();

            Destroy(gameObject);
        }

        private void ExecuteTargetHitBehaviour(ITarget target)
        {
            if (target.Has(out IHealth health))
                health.Damage(Spell.Damage);

            if (target.Has(out AggroManager aggroManager))
                aggroManager.IncreaseAggro(Caster.gameObject.GetComponent<ITarget>(), Spell.LocalAggro);
        }
    }
}
