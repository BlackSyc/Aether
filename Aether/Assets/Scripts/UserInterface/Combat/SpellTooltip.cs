using Aether.Core.Combat;
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

    public void Show(ISpell spell)
    {
        title.text = spell.Name;
        healthDelta.text = spell.HealthDelta.ToString();
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
