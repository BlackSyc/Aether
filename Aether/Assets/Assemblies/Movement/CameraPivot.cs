using UnityEngine;

namespace Aether.Movement
{
    public class CameraPivot : MonoBehaviour
    {
        #region Private Fields
        [SerializeField]
        private float minXRotation = -45;
        [SerializeField]
        private float maxXRotation = 45;

        private float xRotation = 0;
        #endregion

        #region Public Methods
        public void Rotate(Vector2 rotationInput, float rotationSpeed)
        {
            Vector2 lookInput = rotationInput * rotationSpeed * Time.deltaTime;

            xRotation -= lookInput.y;
            xRotation = Mathf.Clamp(xRotation, minXRotation, maxXRotation);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }
        #endregion
    }
}
