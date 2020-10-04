using Syc.Combat.Auras.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aether.UserInterface.Combat
{
	public class AuraTooltip : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI title;

		[SerializeField] private Image icon;

		[SerializeField] private TextMeshProUGUI description;
	
		[SerializeField] private TextMeshProUGUI duration;

		[SerializeField] private TextMeshProUGUI maximumStacks;
		
		public Aura CurrentAura { get; private set; }


		public void Hide()
		{
			CurrentAura = null;
			gameObject.SetActive(false);
		}

		public void Show(Aura aura)
		{
			CurrentAura = aura;
			title.text = aura.AuraName;
			icon.sprite = aura.Icon;
			description.text = aura.Description;
			duration.text = ((int) aura.Duration).ToString();
			maximumStacks.text = aura.StackLimit > 1
				? $"Can stack to {aura.StackLimit} times"
				: string.Empty;
			
			gameObject.SetActive(true);
		}
	}
}
