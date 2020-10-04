using System;
using System.Collections;
using System.Collections.Generic;
using Aether.UserInterface.Combat;
using Syc.Combat.Auras.ScriptableObjects;
using Syc.Combat.SpellSystem.ScriptableObjects;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    [SerializeField] private SpellTooltip spellTooltip;

    [SerializeField] private AuraTooltip auraTooltip;
    public static TooltipManager Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance)
            throw new Exception("There is more than one TooltipManager in the game!");

        Instance = this;
    }

    public void ShowTooltipFor(Spell spell)
    {
        spellTooltip.Show(spell);
    }

    public void ShowTooltipFor(Aura aura)
    {
        auraTooltip.Show(aura);
    }

    public void HideTooltipFor(Aura aura)
    {
        if(auraTooltip.CurrentAura == aura)
            auraTooltip.Hide();
    }
    
    public void HideTooltipFor(Spell spell)
    {
        if(spellTooltip.CurrentSpell == spell)
            spellTooltip.Hide();
    }
}
