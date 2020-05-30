using Aether.Core.Tutorial;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CursorHint : HintObject
{

    [SerializeField]
    public InputAction cursorLockAction;

    [SerializeField]
    private Image tabButtonBackdrop;

    // Start is called before the first frame update
    private void Start()
    {
        cursorLockAction.Enable();
        cursorLockAction.performed += cursorLockActionPerformed;
    }

    private void cursorLockActionPerformed(InputAction.CallbackContext obj)
    {
        tabButtonBackdrop.enabled = true;
        cursorLockAction.performed -= cursorLockActionPerformed;

        Destroy();
    }

    private void OnDestroy()
    {
        cursorLockAction.Disable();
    }
}
