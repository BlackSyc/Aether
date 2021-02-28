using System;
using System.Globalization;
using System.Linq;
using Aether.Core;
using Syc.Combat;
using Syc.Combat.SpellSystem.ScriptableObjects;
using Syc.Combat.SpellSystem.ScriptableObjects.SpellEffects.Health;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class SpellTooltip : MonoBehaviour, ILocalPlayerLink
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI healthDelta;
    [SerializeField] private TextMeshProUGUI casttime;
    [SerializeField] private TextMeshProUGUI cooldown;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI canBeCastWhileMoving;
    [SerializeField] private Image icon;
    public Spell CurrentSpell { get; private set; }

    private Player _player;

    private void Awake()
    {
        Player.LinkToLocalPlayer(this);
    }

    private void OnDestroy()
    {
        Player.UnlinkFromLocalPlayer(this);
    }

    public void Show(Spell spell)
    {
        CurrentSpell = spell;
        title.text = spell.SpellName;
        healthDelta.text = GetHealthDelta(spell);
        casttime.text = spell.CastTime.ToString(CultureInfo.InvariantCulture);
        cooldown.text = spell.CoolDown.ToString(CultureInfo.InvariantCulture);
        description.text = spell.SpellDescription;
        canBeCastWhileMoving.text = "CastWhileMoving is not implemented";
        icon.sprite = spell.Icon;

        gameObject.SetActive(true);
    }

    private string GetHealthDelta(Spell spell)
    {
        if (!_player || _player.Has(out ICombatSystem combatSystem))
            return "?";

        if (spell.SpellEffects.OfType<DealDamage>().Any())
        {
            var minimumDamageAmount = spell.SpellEffects
                .OfType<DealDamage>()
                .Select(x => x.CalculateDamageAmountWith(combatSystem.AttributeSystem))
                .Sum();

            var maximumDamageAmount = spell.SpellEffects
                .OfType<DealDamageFromRange>()
                .Select(x => x.CalculateDamageCeilingWith(combatSystem.AttributeSystem))
                .Sum();

            return maximumDamageAmount <= minimumDamageAmount
                ? $"{minimumDamageAmount:0}"
                : $"{minimumDamageAmount:0} - {maximumDamageAmount:0}";
        }

        if (!spell.SpellEffects.OfType<ApplyHeal>().Any())
            return "?";
        
        var minimumHealAmount = spell.SpellEffects
            .OfType<ApplyHeal>()
            .Select(x => x.CalculateHealAmountWith(combatSystem.AttributeSystem))
            .Sum();

        var maximumHealAmount = spell.SpellEffects
            .OfType<ApplyHealFromRange>()
            .Select(x => x.CalculateHealCeilingWith(combatSystem.AttributeSystem))
            .Sum();

        return maximumHealAmount <= minimumHealAmount
            ? $"{minimumHealAmount:0}"
            : $"{minimumHealAmount:0} - {maximumHealAmount:0}";

    }

    internal void Hide()
    {
        CurrentSpell = null;
        gameObject.SetActive(false);
    }

    public void OnLocalPlayerLinked(Player player)
    {
        _player = player;
    }

    public void OnLocalPlayerUnlinked(Player player)
    {
        _player = null;
    }
}
