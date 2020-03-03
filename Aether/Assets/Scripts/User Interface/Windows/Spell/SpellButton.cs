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

    public void LinkToSpellType(SpellType spellType)
    {
        linkedSpellType = spellType;
        linkedSpellType.SpellChanged.AddListener(ChangeSpell);
        linkedSpellType.NewSpellCast.AddListener(NewSpellCast);

        if (linkedSpellType.HasActiveSpell)
        {
            mainPanel.SetActive(true);
            text.text = linkedSpellType.Spell.Name;
        }
    }

    private void NewSpellCast(SpellCast spellCast)
    {
        spellCast.CastEvents.AddListener(HandleSpellCastEvents);
    }

    private void HandleSpellCastEvents(EventType eventType, SpellCast cast)
    {
        if(eventType == EventType.CastProgress)
        {
            
        }
        if(eventType == EventType.CastComplete)
        {
            StartCoroutine(CoolDown(cast.spell.coolDown + Time.time));
        }
    }

    private IEnumerator CoolDown(float until)
    {
        while(Time.time < until)
        {
            text.text = ((int)(until - Time.time)).ToString();
            yield return null;
        }
        text.text = linkedSpellType.Spell.Name;

    }

    private void ChangeSpell()
    {
        mainPanel.SetActive(true);
        text.text = linkedSpellType.Spell.Name;
        //TODO: Change button icon like:
        //icon.sprite = linkedSpellSlot.Spell.Icon;
    }
}
