using UnityEngine;

public class TravellerPlatform : MonoBehaviour
{
    [SerializeField]
    private Aspect triggerConstraint;
    [SerializeField]
    private Interactable interactable;
    [SerializeField]
    private Transform targetLocation;
    
    private Keystone activeKeystone;

    private void Start()
    {
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneActivated += LoadKeystone;
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneDeactivated += UnloadKeystone;
    }

    private void LoadKeystone(Keystone keystone)
    {
        if (keystone == null)
            return;

        if (keystone.Aspect != triggerConstraint)
            return;

        activeKeystone = keystone;
        interactable.IsActive = true;
        Debug.Log($"Load scene for keystone {keystone.Name}");
    }

    private void UnloadKeystone(Keystone keystone)
    {
        if (keystone != activeKeystone)
            return;

        activeKeystone = null;
        interactable.IsActive = false;
        Debug.Log($"Unload scene for keystone {keystone.Name}");
    }

    public void Travel(Interactor interactor, Interactable interactable)
    {
        AetherEvents.GameEvents.PlayerEvents.TravelToPosition(targetLocation.position);
        Debug.Log($"Start travel to keystone {activeKeystone.Name}");
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneActivated -= LoadKeystone;
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneDeactivated -= UnloadKeystone;
    }
}
