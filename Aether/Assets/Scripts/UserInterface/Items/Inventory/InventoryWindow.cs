using Aether.Assets.Assemblies.Core.Items;
using Aether.Core;
using Aether.Core.Cloaks;
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
        if (!Player.Instance.Has(out IShoulder shoulder) || !Player.Instance.Has(out IInventory inventory))
            return;

        if(shoulder.EquippedCloak != null)
            keystoneImageAnimator.SetBool("Show", inventory.ContainsKeystone(x => shoulder.EquippedCloak.Aspect == x.Aspect));
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
