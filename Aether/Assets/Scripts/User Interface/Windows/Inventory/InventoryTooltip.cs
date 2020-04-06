using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InventoryTooltip : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI contentText;

    public void Show()
    {
        contentText.text = string.Empty;
        Player.Instance.Inventory.Keystones
             .Where(x => x.Aspect == Player.Instance.Shoulder.EquippedCloak.Aspect)
             .ForEach(keystone => contentText.text += $"\n'{keystone.Name}' Keystone");

        gameObject.SetActive(true);
    }


    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
