using System;
using System.Globalization;
using Syc.Combat.Auras;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aether.UserInterface.Combat
{
    public class AuraIcon : MonoBehaviour
    {
        public AuraState AuraState { get; private set; }

        [SerializeField]
        private Image image;

        [SerializeField]
        private TextMeshProUGUI durationText;

        [SerializeField] private TextMeshProUGUI stacksText;

        public void SetAuraState(AuraState auraState)
        {
            AuraState = auraState;
            
            if(auraState.AuraType.Icon != null)
                image.sprite = auraState.AuraType.Icon;
        }

        public void ShowTooltip()
        {
            TooltipManager.Instance.ShowTooltipFor(AuraState.AuraType);
        }

        public void HideTooltip()
        {
            TooltipManager.Instance.HideTooltipFor(AuraState.AuraType);
        }

        public void OnDestroy()
        {
            HideTooltip();
        }

        public void Update()
        {
            if (AuraState == null)
                return;
            
            durationText.text = ((int)(AuraState.AuraType.Duration - AuraState.ElapsedTime)).ToString(CultureInfo.InvariantCulture);
            var stacks = AuraState.Stacks;
            stacksText.text = stacks < 2 
                ? string.Empty
                : stacks.ToString();
        }
    }
}
