using Aether.Core.Tutorial;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class MovementHint : HintObject
{
    [SerializeField]
    private Image w;

    [SerializeField]
    private Image a;

    [SerializeField]
    private Image s;

    [SerializeField]
    private Image d;

    [SerializeField]
    private Image mouse;

    [SerializeField]
    public InputAction wAction;

    [SerializeField]
    public InputAction aAction;

    [SerializeField]
    public InputAction sAction;

    [SerializeField]
    public InputAction dAction;

    [SerializeField]
    public InputAction mouseAction;

    private void Start()
    {
        wAction.Enable();
        aAction.Enable();
        sAction.Enable();
        dAction.Enable();
        mouseAction.Enable();

        wAction.performed += wPerformed;
        aAction.performed += aPerformed;
        sAction.performed += sPerformed;
        dAction.performed += dPerformed;
        mouseAction.performed += mousePerformed;
    }

    private void OnDestroy()
    {
        wAction.Disable();
        aAction.Disable();
        sAction.Disable();
        dAction.Disable();
        mouseAction.Disable();

        wAction.performed -= wPerformed;
        aAction.performed -= aPerformed;
        sAction.performed -= sPerformed;
        dAction.performed -= dPerformed;
        mouseAction.performed -= mousePerformed;
    }

    private void Delay(Action action)
    {
        StartCoroutine(InvokeDelayed(action, 1));
    }

    private IEnumerator InvokeDelayed(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }



    private void mousePerformed(CallbackContext context)
    {
        Delay(() =>
        {
            mouse.enabled = true;
            TryComplete();
        });

        mouseAction.performed -= mousePerformed;
        mouseAction.Disable();
    }

    private void dPerformed(CallbackContext context)
    {
        d.enabled = true;
        dAction.performed -= dPerformed;
        dAction.Disable();

        TryComplete();
    }

    private void sPerformed(CallbackContext context)
    {
        s.enabled = true;
        sAction.performed -= sPerformed;
        sAction.Disable();

        TryComplete();
    }

    private void aPerformed(CallbackContext context)
    {
        a.enabled = true;
        aAction.performed -= aPerformed;
        aAction.Disable();

        TryComplete();
    }

    private void wPerformed(CallbackContext context)
    {
        w.enabled = true;
        wAction.performed -= wPerformed;
        wAction.Disable();

        TryComplete();
    }

    private void TryComplete()
    {
        if (!w.enabled || !a.enabled || !s.enabled || !d.enabled || !mouse.enabled)
            return;

        Destroy();
    }
}
