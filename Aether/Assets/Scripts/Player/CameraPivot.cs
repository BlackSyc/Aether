using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CameraPivot : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5;

    [SerializeField]
    private float minXRotation = -45;
    [SerializeField]
    private float maxXRotation = 45;

    private float xRotation = 0;

    public void Rotate(CallbackContext context)
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Vector2 lookInput = context.ReadValue<Vector2>() * rotationSpeed * Time.deltaTime;

            xRotation -= lookInput.y;
            xRotation = Mathf.Clamp(xRotation, minXRotation, maxXRotation);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }
    }
}
