using Aether.Combat.Modifiers;
using System.Collections.Generic;
using UnityEngine;

namespace Aether.Combat.Panels
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
            modifierSlots.OnModifierAdded -= AddModifierIcon;
            modifierSlots.OnModifierRemoved -= RemoveModifierIcon;
        }

        private void RemoveModifierIcon(Modifier modifier)
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

        private void AddModifierIcon(Modifier modifier)
        {
            var newIcon = Instantiate(modifierIconPrefab, transform).GetComponent<ModifierIcon>();
            newIcon.transform.localScale = new Vector3(iconScale, iconScale, iconScale);
            newIcon.SetModifier(modifier);
            modifierIcons.Add(newIcon);
        }
    }
}
