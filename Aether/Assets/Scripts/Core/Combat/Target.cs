using UnityEngine;

namespace Aether.Core.Combat
{
    public class Target
    {
        private ICombatSystem target;

        private Vector3 relativeHitPoint;

        public Vector3 RelativeHitPoint => relativeHitPoint;

        public Target(ICombatSystem target, Vector3 relativeHitPoint)
        {
            this.target = target;
            this.relativeHitPoint = relativeHitPoint;
        }

        public Target(Vector3 hitPoint)
        {
            this.relativeHitPoint = hitPoint;
        }

        public Target(ICombatSystem target)
        {
            this.target = target;
            relativeHitPoint = target.Transform.Position;
        }

        public bool HasCombatTarget(out ICombatSystem target)
        {
            if (this.target != null)
            {
                target = this.target;
                return true;
            }

            target = null;
            return false;
        }

        public bool HasCombatTarget()
        {
            return target != null;
        }
    }
}
