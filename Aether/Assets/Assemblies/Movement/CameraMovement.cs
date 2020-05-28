using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Aether.Movement
{
    [RequireComponent(typeof(Camera))]
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private Transform cameraPivot;
        [SerializeField]
        private LayerMask ignoreRaycastLayerMask;

        [SerializeField]
        private float zoomSpeed = 2;
        [SerializeField]
        private float zoomDistanceMultiplier = 0.001f;
        [SerializeField]
        private float minZoomDistance = 2.5f;
        [SerializeField]
        private float maxZoomDistance = 5f;
        [SerializeField]
        private float preferedZoomDistance = 3.5f;

        private Camera cam;

        public void Awake()
        {
            cam = GetComponent<Camera>();
        }

        public void Update()
        {
            if (transform.parent != cameraPivot)
            {
                transform.parent = cameraPivot;
                transform.LookAt(cameraPivot);
            }

            if (IsVisionObstructed(out Vector3 newPosition))
            {
                transform.position = newPosition;
            }
            else
            {
                SmoothZoom();
            }
        }

        private bool IsVisionObstructed(out Vector3 newPosition)
        {
            newPosition = transform.position;

            Vector3 pivotPosition = cameraPivot.position;
            Vector3 cameraPosition = transform.position;

            var cameraDistance = Vector3.Distance(pivotPosition, cameraPosition);
            var raycastDirection = cameraPosition - pivotPosition;

            if (Physics.Raycast(pivotPosition, raycastDirection, out RaycastHit hit, preferedZoomDistance, ~ignoreRaycastLayerMask))
            {
                var hitPointDistance = Vector3.Distance(pivotPosition, hit.point);
                if (hitPointDistance < cameraDistance + 0.05f)
                {
                    newPosition = hit.point;
                    Debug.DrawLine(pivotPosition, cameraPosition, Color.red);
                    return true;
                }
            }

            Debug.DrawLine(pivotPosition, cameraPosition, Color.green);
            return false;
        }

        public void Zoom(CallbackContext context)
        {
            Vector2 zoomInput = context.ReadValue<Vector2>();

            preferedZoomDistance -= zoomInput.y * zoomDistanceMultiplier;
            preferedZoomDistance = Mathf.Clamp(preferedZoomDistance, minZoomDistance, maxZoomDistance);
        }

        private void SmoothZoom()
        {
            float distanceFromPivot = Vector3.Distance(transform.position, cameraPivot.transform.position);
            float distanceToPreference = Mathf.Abs(preferedZoomDistance - distanceFromPivot);
            float actualZoomSpeed = zoomSpeed * distanceToPreference;

            if (preferedZoomDistance + 0.05f < distanceFromPivot) // zoom in
            {
                transform.Translate(transform.forward * actualZoomSpeed * Time.deltaTime, Space.World);
            }
            else if (preferedZoomDistance - 0.05f > distanceFromPivot) // zoom out 
            {
                transform.Translate(-transform.forward * actualZoomSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
