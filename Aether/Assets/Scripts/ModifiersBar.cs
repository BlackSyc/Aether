using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiersBar : MonoBehaviour
{
    [SerializeField]
    private GameObject modifierIconPrefab;

    private List<ModifierIcon> modifierIcons;

    private IModifierSlots modifierSlots;

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
        newIcon.SetModifier(modifier);
        modifierIcons.Add(newIcon);
    }
}
