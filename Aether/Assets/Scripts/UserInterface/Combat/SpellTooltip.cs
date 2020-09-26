using System.Globalization;
using Syc.Combat.SpellSystem.ScriptableObjects;
using TMPro;
using UnityEngine;

public class SpellTooltip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;

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
        title.text = spell.SpellName;
        healthDelta.text = "0";
        casttime.text = spell.CastTime.ToString(CultureInfo.InvariantCulture);
        cooldown.text = spell.CoolDown.ToString(CultureInfo.InvariantCulture);
        description.text = spell.SpellDescription;
        canBeCastWhileMoving.text = "CastWhileMoving is not implemented";

        gameObject.SetActive(true);
    }

    internal void Hide()
    {
        gameObject.SetActive(false);
    }
}
