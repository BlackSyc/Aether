using Aether.Assets.Assemblies.Core.Items;
using Aether.Core;
using Aether.Core.Cloaks;
using Aether.Core.Extensions;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Inventory
{
    public class InventoryTooltip : MonoBehaviour
    {

        [SerializeField]
        private TextMeshProUGUI contentText;

        public void Show()
        {
            var playerShoulder = Player.Instance.Get<IShoulder>();
            
            contentText.text = string.Empty;


            Player.Instance.Get<IInventory>().Keystones
                 .Where(x => x.Aspect == playerShoulder.EquippedCloak.Aspect)
                 .ForEach(keystone => contentText.text += $"\n'{keystone.Name}' Keystone");

            gameObject.SetActive(true);
        }


        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
