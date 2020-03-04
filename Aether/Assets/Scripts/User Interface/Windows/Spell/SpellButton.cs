using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour
{
    private SpellType linkedSpellType;

    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Animator castBar;

    public void LinkToSpellType(SpellType spellType)
    {
        linkedSpellType = spellType;
        linkedSpellType.NewSpellCast += NewSpellCast;
        linkedSpellType.SpellChanged += ChangeSpell;

        if (linkedSpellType.HasActiveSpell)
        {
            mainPanel.SetActive(true);
            text.text = linkedSpellType.Spell.Name;
        }
    }

    private void NewSpellCast(SpellCast spellCast)
    {
        castBar.Play("Cast", -1, 0f);

        spellCast.CastProgress += x => castBar.Play("Cast", -1, x.Progress);
        spellCast.CastCancelled += x => castBar.Play("CastCancelled", -1);
        spellCast.CastComplete += x =>
        {
            castBar.Play("CastComplete", -1, 0f);
            StartCoroutine(CoolDown(x.Spell.CoolDown + Time.time));
        };
    }

    private IEnumerator CoolDown(float until)
    {
        while(Time.time < until)
        {
            text.text = ((int)(until - Time.time) + 1).ToString();
            yield return null;
        }
        text.text = linkedSpellType.Spell.Name;

    }

    private void ChangeSpell(SpellType spellType)
    {
        mainPanel.SetActive(true);
        text.text = spellType.Spell.Name;
        //TODO: Change button icon like:
        //icon.sprite = linkedSpellSlot.Spell.Icon;
    }
}
