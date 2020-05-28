using Aether.Core;
using UnityEngine;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField]
    private Animator keystoneImageAnimator;

    void Start()
    {
        Aether.Core.Items.Events.OnPickedUpKeystone += UpdateKeystoneImage;
        Aether.Core.Items.Events.OnExtractedKeystone += UpdateKeystoneImage;
        Aether.Core.Cloaks.Events.OnCloakUnequipped += _ => UpdateKeystoneImage();
        Aether.Core.Cloaks.Events.OnCloakEquipped += _ => UpdateKeystoneImage();
        UpdateKeystoneImage();
    }

    private void UpdateKeystoneImage()
    {
        if(Player.Instance.Shoulder.EquippedCloak != null)
            keystoneImageAnimator.SetBool("Show", Player.Instance.Inventory.ContainsKeystone(x => Player.Instance.Shoulder.EquippedCloak.Aspect == x.Aspect));
        else
            keystoneImageAnimator.SetBool("Show", false);
    }

    private void OnDestroy()
    {
        Aether.Core.Items.Events.OnPickedUpKeystone -= UpdateKeystoneImage;
        Aether.Core.Items.Events.OnExtractedKeystone -= UpdateKeystoneImage;
        Aether.Core.Cloaks.Events.OnCloakUnequipped -= _ => UpdateKeystoneImage();
        Aether.Core.Cloaks.Events.OnCloakEquipped -= _ => UpdateKeystoneImage();
    }
}
