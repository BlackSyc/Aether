using System;
using TMPro;
using UnityEngine;

public class SpellTooltip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private TextMeshProUGUI healthDeltaLabel;

    [SerializeField]
    private TextMeshProUGUI healthDelta;


    [SerializeField]
    private TextMeshProUGUI casttime;


    [SerializeField]
    private TextMeshProUGUI cooldown;


    [SerializeField]
    private TextMeshProUGUI description;


    [SerializeField]
    private TextMeshProUGUI canBeCastWhileMoving;


    public void Show(Spell spell)
    {
        title.text = spell.Name;
        healthDeltaLabel.text = spell.HealthDelta > 0 ? "Heal:" : "Damage:";
        healthDelta.text = spell.HealthDelta < 0 ? (spell.HealthDelta * -1).ToString() : spell.HealthDelta.ToString();
        casttime.text = spell.CastDuration.ToString();
        cooldown.text = spell.CoolDown.ToString();
        description.text = spell.Description;
        canBeCastWhileMoving.text = spell.CastWhileMoving ? "Can be cast while moving" : "Can not be cast while moving";

        gameObject.SetActive(true);
    }

    internal void Hide()
    {
        gameObject.SetActive(false);
    }
}
