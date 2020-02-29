using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5;

    public void Rotate(CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        Vector3 localRotation = -transform.right * lookInput.y * rotationSpeed;
        transform.Rotate(localRotation * Time.deltaTime, Space.World);
    }
}
