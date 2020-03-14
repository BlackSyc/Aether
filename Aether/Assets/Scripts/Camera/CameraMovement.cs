using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

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

        Vector3 from = cameraPivot.position;
        Vector3 to = transform.position;

        var pivotCameraDistance = Vector3.Distance(from, to);
        if (Physics.Raycast(from, to - from, out RaycastHit hit, preferedZoomDistance, ~ignoreRaycastLayerMask) && Vector3.Distance(from, hit.point) < pivotCameraDistance +0.1f)
        {
            Debug.Log(hit.collider.name);
            Debug.DrawLine(from, to, Color.red);
            transform.position = hit.point;
        }
        else
        {
            Debug.DrawLine(from, to, Color.green);
            SmoothZoom();
        }
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

        if (preferedZoomDistance + 0.1f < distanceFromPivot) // zoom in
        {
            transform.Translate(transform.forward * actualZoomSpeed * Time.deltaTime, Space.World);
        }
        else if (preferedZoomDistance - 0.1f > distanceFromPivot) // zoom out 
        {
            transform.Translate(-transform.forward * actualZoomSpeed * Time.deltaTime, Space.World);
        }
    }
}
