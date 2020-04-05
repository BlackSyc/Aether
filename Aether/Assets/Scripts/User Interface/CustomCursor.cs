using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class CustomCursor : MonoBehaviour
{
    // Update is called once per frame
    public void CursorMoved(CallbackContext context)
    {
        transform.position = context.ReadValue<Vector2>();
    }
}
