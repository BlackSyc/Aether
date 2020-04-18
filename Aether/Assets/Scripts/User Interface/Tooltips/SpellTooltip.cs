using Aether.SpellSystem.ScriptableObjects;
using TMPro;
using UnityEngine;

public class SpellTooltip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private TextMeshProUGUI damage;


    [SerializeField]
    private TextMeshProUGUI casttime;


    [SerializeField]
    private TextMeshProUGUI cooldown;


    [SerializeField]
    private TextMeshProUGUI description;


    [SerializeField]
    private TextMeshProUGUI canBeCastWhileMoving;

    [SerializeField]
    private TextMeshProUGUI heal;

    public void Show(Spell spell)
    {
        title.text = spell.Name;
        heal.text = spell.Heal.ToString();
        damage.text = spell.Damage.ToString();
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
