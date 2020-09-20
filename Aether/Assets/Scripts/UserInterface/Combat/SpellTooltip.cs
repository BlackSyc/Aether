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

    public void Show(SpellBehaviour spellBehaviour)
    {
        title.text = spellBehaviour.SpellName;
        healthDelta.text = "0";
        casttime.text = spellBehaviour.CastTime.ToString(CultureInfo.InvariantCulture);
        cooldown.text = spellBehaviour.CoolDown.ToString(CultureInfo.InvariantCulture);
        description.text = spellBehaviour.SpellDescription;
        canBeCastWhileMoving.text = "CastWhileMoving is not implemented";

        gameObject.SetActive(true);
    }

    internal void Hide()
    {
        gameObject.SetActive(false);
    }
}
