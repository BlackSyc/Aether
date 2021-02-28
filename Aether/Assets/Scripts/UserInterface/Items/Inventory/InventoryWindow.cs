using Aether.Assets.Assemblies.Core.Items;
using Aether.Core;
using Aether.Core.Cloaks;
using UnityEngine;

public class InventoryWindow : MonoBehaviour, ILocalPlayerLink
{
    [SerializeField]
    private Animator keystoneImageAnimator;

    private Player _player;

    void Start()
    {
        Aether.Core.Items.Events.OnPickedUpKeystone += UpdateKeystoneImage;
        Aether.Core.Items.Events.OnExtractedKeystone += UpdateKeystoneImage;
    }

    private void UpdateKeystoneImage(ICloak _)
    {
        if (!_player)
        {
            return;
        }
        
        if (!_player.Has(out IShoulder shoulder) || !_player.Has(out IInventory inventory))
            return;

        if (shoulder.EquippedCloak != null)
            keystoneImageAnimator.SetBool("Show", inventory.ContainsKeystone(x => shoulder.EquippedCloak.Aspect == x.Aspect));
        else
            keystoneImageAnimator.SetBool("Show", false);
    }

    private void UpdateKeystoneImage() => UpdateKeystoneImage(default);

    private void OnDestroy()
    {
        Aether.Core.Items.Events.OnPickedUpKeystone -= UpdateKeystoneImage;
        Aether.Core.Items.Events.OnExtractedKeystone -= UpdateKeystoneImage;
        Player.UnlinkFromLocalPlayer(this);
    }

    public void OnLocalPlayerLinked(Player player)
    {
        if (player.Has(out IShoulder shoulder))
            shoulder.OnCloakChanged += UpdateKeystoneImage;

        UpdateKeystoneImage();
        _player = player;
    }

    public void OnLocalPlayerUnlinked(Player player)
    {
        if (player.Has(out IShoulder shoulder))
            shoulder.OnCloakChanged -= UpdateKeystoneImage;

        _player = null;
    }
}
