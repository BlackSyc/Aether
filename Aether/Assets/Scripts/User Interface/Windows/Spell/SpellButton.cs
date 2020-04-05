using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour
{
    [SerializeField]
    private SpellSlot spellSlot;

    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Animator castBar;

    [SerializeField]
    private SpellTooltip spellTooltip;

    public void ShowTooltip()
    {
        spellTooltip.Show(spellSlot.State.Spell);
    }

    public void HideTooltip()
    {
        spellTooltip.Hide();
    }

    private void Start()
    {
        if (spellSlot == null)
            return;

        if (spellSlot.HasActiveSpell)
        {
            mainPanel.SetActive(true);
            text.text = spellSlot.State.Spell.Name;
        }

        spellSlot.OnSpellChanged += ChangeSpell;
        SpellCast.Events.OnCastSpell += StartSpellCast;
    }

    private void ChangeSpell(Spell spell)
    {
        if(spell == null)
        {
            mainPanel.SetActive(false);
            return;
        }

        if (spell.PreferredSpellSlot == this.spellSlot)
        {
            mainPanel.SetActive(true);
            text.text = spell.Name;
            //TODO: Change button icon like: icon.sprite = linkedSpellSlot.Spell.Icon;
        }
    }

    private void StartSpellCast(SpellCast spellCast)
    {
        castBar.Play("Cast", -1, 0f);
        SubscribeToSpellCast(spellCast);
    }

    private void UpdateCast(float progress)
    {
        castBar.Play("Cast", -1, progress);
    }

    private void CancelCast(SpellCast spellCast)
    {
        castBar.SetTrigger("CastCancelled");
        UnSubscribeFromSpellCast(spellCast);
    }

    private void CompleteCast(SpellCast spellCast)
    {
        castBar.SetTrigger("CastComplete");
        StartCoroutine(CoolDown(spellCast.Spell.CoolDown + Time.time));
        UnSubscribeFromSpellCast(spellCast);
    }

    private void SubscribeToSpellCast(SpellCast spellCast)
    {
        spellCast.CastProgress += UpdateCast;
        spellCast.CastCancelled += CancelCast;
        spellCast.CastComplete += CompleteCast;
    }

    private void UnSubscribeFromSpellCast(SpellCast spellCast)
    {
        spellCast.CastCancelled -= CancelCast;
        spellCast.CastComplete -= CompleteCast;
    }

    private IEnumerator CoolDown(float until)
    {
        while (Time.time < until)
        {
            text.text = ((int)(until - Time.time) + 1).ToString();
            yield return null;
        }
        text.text = spellSlot.State.Spell.Name;
    }

    private void OnDestroy()
    { 
        if(spellSlot != null)
            spellSlot.OnSpellChanged -= ChangeSpell;

        SpellCast.Events.OnCastSpell -= StartSpellCast;
    }
}
