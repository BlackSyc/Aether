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
        foreach (Keystone keystone in Player.Instance.Inventory.Keystones
            .Where(x => x.Aspect == Player.Instance.Shoulder.EquippedCloak.Aspect))
        {
            if (!contentText.text.Equals(string.Empty))
            {
                contentText.text += "\n";
            }
            contentText.text += $"'{keystone.Name}' Keystone";
        }
        gameObject.SetActive(true);
    }


    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
