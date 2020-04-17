using ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField]
    private Animator keystoneImageAnimator;

    void Start()
    {
        Inventory.Events.OnPickedUpKeystone += UpdateKeystoneImage;
        Inventory.Events.OnExtractedKeystone += UpdateKeystoneImage;
        Cloak.Events.OnCloakUnequipped += _ => UpdateKeystoneImage();
        Cloak.Events.OnCloakEquipped += _ => UpdateKeystoneImage();
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
        Inventory.Events.OnPickedUpKeystone -= UpdateKeystoneImage;
        Inventory.Events.OnExtractedKeystone -= UpdateKeystoneImage;
        Cloak.Events.OnCloakUnequipped -= _ => UpdateKeystoneImage();
        Cloak.Events.OnCloakEquipped -= _ => UpdateKeystoneImage();
    }
}
