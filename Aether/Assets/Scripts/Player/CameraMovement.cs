using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPivot;
    [SerializeField]
    private float rotationSpeed = 10;
    [SerializeField]
    private float zoomSpeed = 10f;
    [SerializeField]
    private float zoomDistanceMultiplier = 0.005f;
    [SerializeField]
    private float minZoomDistance = 2.5f;
    [SerializeField]
    private float maxZoomDistance = 10;

    [SerializeField]
    private float preferredZoomDistance = 7.5f;

    [SerializeField]
    private float xRotation = 0;

    public void LateUpdate()
    {
        SmoothZoom();
    }

    public void Rotate(CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>() * rotationSpeed * Time.deltaTime;

        this.xRotation -= lookInput.y;
        this.xRotation = Mathf.Clamp(this.xRotation, -90f, 90f);

        cameraPivot.localRotation = Quaternion.Euler(this.xRotation, 0, 0);
    }

    public void Zoom(CallbackContext context)
    {
        Vector2 zoomInput = context.ReadValue<Vector2>();
        preferredZoomDistance -= zoomInput.y * zoomDistanceMultiplier;

        // clamp
        if (preferredZoomDistance < minZoomDistance)
        {
            preferredZoomDistance = minZoomDistance;
        }
        else if (preferredZoomDistance > maxZoomDistance)
        {
            preferredZoomDistance = maxZoomDistance;
        }
    }

    private void SmoothZoom()
    {
        float distanceFromPivot = Vector3.Distance(transform.position, cameraPivot.transform.position);
        float distanceToPreference = Mathf.Abs(preferredZoomDistance - distanceFromPivot);
        float actualZoomSpeed = zoomSpeed * distanceToPreference;

        if (preferredZoomDistance + 0.1f < distanceFromPivot) // zoom in
        {
            transform.Translate(transform.forward * actualZoomSpeed * Time.deltaTime, Space.World);
        }
        else if (preferredZoomDistance - 0.1f > distanceFromPivot) // zoom out 
        {
            transform.Translate(-transform.forward * actualZoomSpeed * Time.deltaTime, Space.World);
        }
    }
}
