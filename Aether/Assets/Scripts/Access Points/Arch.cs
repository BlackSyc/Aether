using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arch : MonoBehaviour
{
    [SerializeField]
    private Aspect triggerConstraint;

    [SerializeField]
    private Interactable interactable;
    
    private Keystone activeKeystone;

    private void Start()
    {
        AetherEvents.KeystoneEvents.OnKeystoneActivated += LoadKeystone;
        AetherEvents.KeystoneEvents.OnKeystoneDeactivated += UnloadKeystone;
    }

    private void UnloadKeystone(Keystone keystone)
    {
        if (keystone != activeKeystone)
            return;

        activeKeystone = null;
        interactable.IsActive = false;
        Debug.Log(string.Format("Unload scene for keystone {0}", keystone.Name));
    }

    private void LoadKeystone(Keystone keystone)
    {
        if(keystone == null)
            return;

        if (keystone.Aspect != triggerConstraint)
            return;

        activeKeystone = keystone;
        interactable.IsActive = true;
        Debug.Log(string.Format("Load scene for keystone {0}", keystone.Name));
    }

    public void StepThrough(Interactor interactor, Interactable interactable)
    {
        AetherEvents.GameEvents.HubEvents.TravelToAccessPoint();
        Debug.Log(string.Format("Start travel to keystone {0}", activeKeystone.Name));
    }

    private void OnDestroy()
    {
        AetherEvents.KeystoneEvents.OnKeystoneActivated -= LoadKeystone;
    }
}
