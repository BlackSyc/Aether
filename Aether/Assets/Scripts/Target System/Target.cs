using UnityEngine;

namespace Aether.TargetSystem
{
    public class Target
    {
        #region Private Fields
        private readonly Vector3 targetPosition;
        #endregion

        #region Public Properties
        public Vector3 Position => HasTargetTransform ? TargetTransform.position : targetPosition;

        public bool HasTargetTransform => TargetTransform != null;

        public Transform TargetTransform { get; private set; }
        #endregion

        #region Constructors
        public Target(Vector3 position)
        {
            TargetTransform = null;
            this.targetPosition = position;
        }

        public Target(Transform targetTransform)
        {
            this.TargetTransform = targetTransform;
        }
        #endregion
    }
}
