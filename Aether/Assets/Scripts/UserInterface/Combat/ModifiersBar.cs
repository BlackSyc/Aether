using System.Collections.Generic;
using Syc.Combat.ModifierSystem;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class ModifiersBar : MonoBehaviour
    {
        [SerializeField]
        private GameObject modifierIconPrefab;

        private List<ModifierIcon> _modifierIcons;

        private ModifierSystem _modifierSystem;

        [SerializeField]
        private float iconScale = 1;

        private void Start()
        {
            _modifierIcons = new List<ModifierIcon>();
        }

        public void SetModifierSystem(ModifierSystem modifierSystem)
        {
            this._modifierSystem = modifierSystem;
            modifierSystem.OnModifierAdded += AddModifierIcon;
            modifierSystem.OnModifierRemoved += RemoveModifierIcon;
        }

        private void OnDestroy()
        {
            if (_modifierSystem == null)
                return;

            _modifierSystem.OnModifierAdded -= AddModifierIcon;
            _modifierSystem.OnModifierRemoved -= RemoveModifierIcon;
        }

        private void RemoveModifierIcon(Modifier modifier)
        {
            _modifierIcons.RemoveAll(x =>
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
            newIcon.SetModifierBehaviour(modifier);
            _modifierIcons.Add(newIcon);
        }
    }
}
