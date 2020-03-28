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
        UpdateKeystoneImage();
    }

    private void UpdateKeystoneImage()
    {
        if(Player.Instance.Shoulder.EquippedCloak != null)
            keystoneImageAnimator.SetBool("Show", Player.Instance.Inventory.ContainsKeystone(x => Player.Instance.Shoulder.EquippedCloak.Aspect == x.Aspect));
    }

    private void OnDestroy()
    {
        Inventory.Events.OnPickedUpKeystone -= UpdateKeystoneImage;
        Inventory.Events.OnExtractedKeystone -= UpdateKeystoneImage;
    }
}
