using Aether.Core.Combat;
using System.Collections.Generic;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class ModifiersBar : MonoBehaviour
    {
        [SerializeField]
        private GameObject modifierIconPrefab;

        private List<ModifierIcon> modifierIcons;

        private IModifierSlots modifierSlots;

        [SerializeField]
        private float iconScale = 1;

        private void Start()
        {
            modifierIcons = new List<ModifierIcon>();
        }

        public void SetModifierSlots(IModifierSlots modifierSlots)
        {
            this.modifierSlots = modifierSlots;
            modifierSlots.OnModifierAdded += AddModifierIcon;
            modifierSlots.OnModifierRemoved += RemoveModifierIcon;
        }

        private void OnDestroy()
        {
            if (modifierSlots == null)
                return;

            modifierSlots.OnModifierAdded -= AddModifierIcon;
            modifierSlots.OnModifierRemoved -= RemoveModifierIcon;
        }

        private void RemoveModifierIcon(IModifierType modifier)
        {
            modifierIcons.RemoveAll(x =>
            {
                if (x.Modifier == modifier)
                {
                    Destroy(x.gameObject);
                    return true;
                }
                return false;
            });
        }

        private void AddModifierIcon(IModifierType modifier)
        {
            var newIcon = Instantiate(modifierIconPrefab, transform).GetComponent<ModifierIcon>();
            newIcon.transform.localScale = new Vector3(iconScale, iconScale, iconScale);
            newIcon.SetModifier(modifier);
            modifierIcons.Add(newIcon);
        }
    }
}
