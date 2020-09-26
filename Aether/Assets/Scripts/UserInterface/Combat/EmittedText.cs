using Aether.Core;
using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(Rigidbody))]
    public class EmittedText : MonoBehaviour
    {

        public TextMeshProUGUI text;

        public Rigidbody rigidBodyComponent;

        private CanvasGroup _canvasGroup;

        private Transform _mainCameraTransform;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            rigidBodyComponent = GetComponent<Rigidbody>();
            
            if (!(Camera.main is null))
            {
                _mainCameraTransform = Camera.main.transform;
            }

            Destroy(gameObject, 2);
        }

        protected virtual void LateUpdate()
        {
            transform.rotation = Quaternion.LookRotation(_mainCameraTransform.forward, _mainCameraTransform.up);

            var distanceToCamera = Vector3.Distance(transform.position, _mainCameraTransform.position);

            _canvasGroup.alpha = distanceToCamera - 3;
        }
    }
}
