using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTarget;
    [SerializeField]
    private float zoomSpeed = 2;
    [SerializeField]
    private float zoomDistanceMultiplier = 0.001f;

    [SerializeField]
    private float minZoomDistance = 2.5f;
    [SerializeField]
    private float maxZoomDistance = 5f;
    [SerializeField]
    private float zoomDistance = 3.5f;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    public void Update()
    {
        if (transform.parent != cameraTarget)
        {
            transform.parent = cameraTarget;
            transform.LookAt(cameraTarget);
        }

        // Is vision Obstructed?
        if (IsViewportObstructed(out float distanceToObstruction))
        {
            //transform.Translate(transform.forward * distanceToObstruction, Space.World);
        }
        // Is usefull to move back?
        else
        {
            //SmoothZoom();
        }
    }

    public void Zoom(CallbackContext context)
    {
        Vector2 zoomInput = context.ReadValue<Vector2>();

        zoomDistance -= zoomInput.y * zoomDistanceMultiplier;
        zoomDistance = Mathf.Clamp(zoomDistance, minZoomDistance, maxZoomDistance);
    }

    private bool IsViewportObstructed(out float distanceToObstruction)
    {
        var maxDistance = 0f;

        bool Raycast(Vector3 pos1, Vector3 pos2)
        {
            if (Physics.Raycast(pos1, pos2 - pos1, out RaycastHit hit, Vector3.Distance(pos1, pos2)))
            {
                var distance = Vector3.Distance(hit.point, transform.position);
                if (distance > maxDistance)
                    maxDistance = distance;

                return true;
            }
            return false;
        };

        Vector3 to = cameraTarget.position;
        var viewportPoints = new List<Vector3>
        {
            new Vector3(0, 0, cam.nearClipPlane),
            new Vector3(0, 1, cam.nearClipPlane),
            new Vector3(1, 0, cam.nearClipPlane),
            new Vector3(1, 1, cam.nearClipPlane)
        };

        foreach (var viewportPoint in viewportPoints)
        {
            var from = cam.ViewportToWorldPoint(viewportPoint);

            if (Raycast(from, to) || Raycast(to, from))
            {
                Debug.DrawLine(from, to, Color.red);
            }
            else
            {
                Debug.DrawLine(from, to, Color.green);
            }
        }

        distanceToObstruction = maxDistance;
        return distanceToObstruction > 0;
    }

    private void SmoothZoom()
    {
        float distanceFromPivot = Vector3.Distance(transform.position, cameraTarget.transform.position);
        float distanceToPreference = Mathf.Abs(zoomDistance - distanceFromPivot);
        float actualZoomSpeed = zoomSpeed * distanceToPreference;

        if (zoomDistance + 0.1f < distanceFromPivot) // zoom in
        {
            transform.Translate(transform.forward * actualZoomSpeed * Time.deltaTime, Space.World);
        }
        else if (zoomDistance - 0.1f > distanceFromPivot) // zoom out 
        {
            transform.Translate(-transform.forward * actualZoomSpeed * Time.deltaTime, Space.World);
        }
    }
}
